using UnityEngine;

public static class Settings {
    public static class PlayerAnimationKeys {
        public static int xDir;
        public static int yDir;
        public static int Moving;

        static PlayerAnimationKeys(){
            xDir = Animator.StringToHash("xDir");
            yDir = Animator.StringToHash("yDir");
            Moving = Animator.StringToHash("Moving");
        }
    }

    public static class PlayerVariables {
        public const float movementSpeed = 4.333f;
        public const int initialInventoryCapacity = 24;
        public const int maximumInventoryCapacity = 48;
    }


    public static class FadeOutConstants {
        public const float fadeInSeconds = 0.25f;
        public const float fadeOutSeconds = 0.35f;
        public const float targetAlpha = 0.45f;
    }
}
