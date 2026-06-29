// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.GLCamera
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

namespace BanjoKazooieLevelEditor
{
    public class GLCamera
    {
        private Vector3 position = new Vector3(0.0f, 0.0f, -2161f);
        private Vector3 rotation = new Vector3(0.0f, 0.0f, 0.0f);
        private Matrix4 ryMatrix = Matrix4.I;
        private Matrix4 rxMatrix = Matrix4.I;
        private float movementSpeed = 10f;

        public float MovementSpeed
        {
            set => movementSpeed = value;
        }

        public float X
        {
            set => position.x = value;
            get => position.x;
        }

        public float Y
        {
            set => position.y = value;
            get => position.y;
        }

        public float Z
        {
            set => position.z = value;
            get => position.z;
        }

        public float Yaw
        {
            set
            {
                rotation.y = value;
                ryMatrix = Matrix4.GetRotationMatrixY(Core.ToRadians(rotation.y));
            }
            get => rotation.y;
        }

        public float Pitch
        {
            set
            {
                rotation.x = value;
                if (rotation.x < -180.0f)
                    rotation.x = 360f + rotation.x;
                if (rotation.x > 180.0f)
                    rotation.x = 360f - rotation.x;
                rxMatrix = Matrix4.GetRotationMatrixX(Core.ToRadians(rotation.x));
            }
            get => rotation.x;
        }

        public float Roll
        {
            set => rotation.z = value;
            get => rotation.z;
        }

        public float GetXRotation() => rotation.x;

        public float GetYRotation() => rotation.y;

        public float GetZRotation() => rotation.z;

        public void Reset()
        {
            position = new Vector3(0.0f, 0.0f, -2161f);
            rotation = new Vector3(0.0f, 0.0f, 0.0f);
        }

        public void LookAt(Vector3 target)
        {
            rotation.x = 0.0f;
            rotation.y = 0.0f;
            rotation.z = 0.0f;
            position.x = target.x * -1f;
            position.y = target.y * -1.0f - 50.0f;
            position.z = target.z * -1.0f - 500.0f;
            ryMatrix = Matrix4.GetRotationMatrixY(Core.ToRadians(rotation.y));
            rxMatrix = Matrix4.GetRotationMatrixX(Core.ToRadians(rotation.x));
        }

        public void PanUpdate(bool forward, bool back, bool left, bool right, bool moveUp, bool moveDown)
        {
            Matrix4 m = Matrix4.GetRotationMatrix(Core.ToRadians(rotation.x), Core.ToRadians(rotation.y), Core.ToRadians(rotation.z));

            Vector3 vector3 = new Vector3();
            if (forward)
            {
                vector3 += new Vector3(m.matrix[2, 0], m.matrix[2, 1], m.matrix[2, 2]);
            }

            if (back)
            {
                vector3 += new Vector3(-m.matrix[2, 0], -m.matrix[2, 1], -m.matrix[2, 2]);
            }

            if (left)
            {
                vector3 += new Vector3(-m.matrix[0, 0], -m.matrix[0, 1], -m.matrix[0, 2]);
            }

            if (right)
            {
                vector3 += new Vector3(m.matrix[0, 0], m.matrix[0, 1], m.matrix[0, 2]);
            }

            if (moveUp)
            {
                vector3 += new Vector3(0, -1, 0);
            }

            if (moveDown)
            {
                vector3 += new Vector3(0, 1, 0);
            }

            if (vector3 == Vector3.Zero) return;

            position += vector3.Normalize() * movementSpeed;
        }

        public void MouseUpdate(int mouseDeltaX, int mouseDeltaY)
        {
            rotation.y += mouseDeltaX * 0.25f;
            rotation.x += mouseDeltaY * 0.25f;
            if (rotation.x <= -90.0f)
                rotation.x = -90f;
            if (rotation.x >= 90.0f)
                rotation.x = 90f;
            ryMatrix = Matrix4.GetRotationMatrixY(Core.ToRadians(rotation.y));
            rxMatrix = Matrix4.GetRotationMatrixX(Core.ToRadians(rotation.x));
        }

        public float[] GetWorldToViewMatrix() => (rxMatrix * ryMatrix * Matrix4.GetTranslationMatrix(position.x, position.y, position.z)).ToGLMatrix();
    }
}