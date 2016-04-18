using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;

namespace STARS.Kinect.Gestures.Segments
{
    /// <summary>
    /// The Stop gesture segment
    /// </summary>
    public class StopSegment1 : IRelativeGestureSegment
    {
        /// <summary>
        /// Checks the gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
        public GesturePartResult CheckGesture(Skeleton skeleton)
        {
            //Head close to height of right elbow
            if (skeleton.Joints[JointType.Head].Position.Y > skeleton.Joints[JointType.HandRight].Position.Y)
            {
                //right hand to the left of elbow
                if ((skeleton.Joints[JointType.HandRight].Position.X - skeleton.Joints[JointType.ElbowRight].Position.X) < 0.2)
                {
                    //Right hand above soulder
                    if (skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.ShoulderCenter].Position.Y)
                    {
                        return GesturePartResult.Succeed;
                    }
                    return GesturePartResult.Pausing;

                }
                //Not quite at same position
                return GesturePartResult.Fail;
            }
            return GesturePartResult.Fail;
        }
    }
}
