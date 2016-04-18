using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;

namespace STARS.Kinect.Gestures.Segments
{
    /// <summary>
    /// The Scan gesture segment
    /// </summary>
    public class ScanSegment1 : IRelativeGestureSegment
    {
        /// <summary>
        /// Checks the gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
        public GesturePartResult CheckGesture(Skeleton skeleton)
        {
            //Head close to height of right elbow
            if (skeleton.Joints[JointType.ShoulderLeft].Position.Y < skeleton.Joints[JointType.ElbowLeft].Position.Y)
            {
                //right hand to the left of elbow
                if (skeleton.Joints[JointType.HandLeft].Position.X < skeleton.Joints[JointType.ElbowLeft].Position.X)
                {
                    //Right hand above soulder
                    if (skeleton.Joints[JointType.HandLeft].Position.Y > skeleton.Joints[JointType.Head].Position.Y)
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
