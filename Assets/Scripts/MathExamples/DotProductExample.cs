using UnityEngine;
using TMPro;

namespace Objects
{
    public class DotProductExample : MonoBehaviour
    {
        public LineRenderer bot1Line;
        public LineRenderer bot2Line;
        public LineRenderer crossProductLine;

        public Transform bot1;
        public Transform bot2;

        public bool isNormalized;

        public TMP_Text crossValues;

        Vector3 crossProduct;

        private void Update()
        {
            DrawLine();

            CrossProductMath();

            DrawCrossProductLine(crossProduct);
        }

        private void CrossProductMath()
        {
            if (!isNormalized)
                crossProduct = Vector3.Cross(bot1.position, bot2.position);
            else
                crossProduct = Vector3.Cross(bot1.position.normalized, bot2.position.normalized);

        }

        void DrawLine()
        {
            bot1Line.SetPosition(0, transform.position);
            bot1Line.SetPosition(1, bot1.position);

            bot2Line.SetPosition(0, transform.position);
            bot2Line.SetPosition(1, bot2.position);
        }

        void DrawCrossProductLine(Vector3 value)
        {
            crossProductLine.SetPosition(0, transform.position);
            crossProductLine.SetPosition(1, value);
        }
    }
}
