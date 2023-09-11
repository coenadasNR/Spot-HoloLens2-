//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.WebotsSpot
{
    [Serializable]
    public class StackFeedback : Message
    {
        public const string k_RosMessageName = "webots_spot_msgs/Stack";
        public override string RosMessageName => k_RosMessageName;

        public bool stacking;

        public StackFeedback()
        {
            this.stacking = false;
        }

        public StackFeedback(bool stacking)
        {
            this.stacking = stacking;
        }

        public static StackFeedback Deserialize(MessageDeserializer deserializer) => new StackFeedback(deserializer);

        private StackFeedback(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.stacking);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.stacking);
        }

        public override string ToString()
        {
            return "StackFeedback: " +
            "\nstacking: " + stacking.ToString();
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize, MessageSubtopic.Feedback);
        }
    }
}
