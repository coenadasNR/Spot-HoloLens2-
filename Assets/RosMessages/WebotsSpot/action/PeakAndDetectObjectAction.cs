using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;


namespace RosMessageTypes.WebotsSpot
{
    public class PeakAndDetectObjectAction : Action<PeakAndDetectObjectActionGoal, PeakAndDetectObjectActionResult, PeakAndDetectObjectActionFeedback, PeakAndDetectObjectGoal, PeakAndDetectObjectResult, PeakAndDetectObjectFeedback>
    {
        public const string k_RosMessageName = "webots_spot_msgs/PeakAndDetectObjectAction";
        public override string RosMessageName => k_RosMessageName;


        public PeakAndDetectObjectAction() : base()
        {
            this.action_goal = new PeakAndDetectObjectActionGoal();
            this.action_result = new PeakAndDetectObjectActionResult();
            this.action_feedback = new PeakAndDetectObjectActionFeedback();
        }

        public static PeakAndDetectObjectAction Deserialize(MessageDeserializer deserializer) => new PeakAndDetectObjectAction(deserializer);

        PeakAndDetectObjectAction(MessageDeserializer deserializer)
        {
            this.action_goal = PeakAndDetectObjectActionGoal.Deserialize(deserializer);
            this.action_result = PeakAndDetectObjectActionResult.Deserialize(deserializer);
            this.action_feedback = PeakAndDetectObjectActionFeedback.Deserialize(deserializer);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.action_goal);
            serializer.Write(this.action_result);
            serializer.Write(this.action_feedback);
        }

    }
}
