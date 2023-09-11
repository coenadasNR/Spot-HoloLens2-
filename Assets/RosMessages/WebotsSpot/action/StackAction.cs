using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;


namespace RosMessageTypes.WebotsSpot
{
    public class StackAction : Action<StackActionGoal, StackActionResult, StackActionFeedback, StackGoal, StackResult, StackFeedback>
    {
        public const string k_RosMessageName = "webots_spot_msgs/StackAction";
        public override string RosMessageName => k_RosMessageName;


        public StackAction() : base()
        {
            this.action_goal = new StackActionGoal();
            this.action_result = new StackActionResult();
            this.action_feedback = new StackActionFeedback();
        }

        public static StackAction Deserialize(MessageDeserializer deserializer) => new StackAction(deserializer);

        StackAction(MessageDeserializer deserializer)
        {
            this.action_goal = StackActionGoal.Deserialize(deserializer);
            this.action_result = StackActionResult.Deserialize(deserializer);
            this.action_feedback = StackActionFeedback.Deserialize(deserializer);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.action_goal);
            serializer.Write(this.action_result);
            serializer.Write(this.action_feedback);
        }

    }
}
