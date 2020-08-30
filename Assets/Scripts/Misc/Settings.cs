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
    }
}
