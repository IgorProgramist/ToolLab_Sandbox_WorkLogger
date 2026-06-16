using TMPro;
using UnityEngine;
using UnityToolLab.Logging;

namespace UnityToolLab.TMP
{
    [DisallowMultipleComponent]
    public class TmpAlphaFadeIn : MonoBehaviour
    {
        private const string ToolId = "TMP_001";

        [SerializeField] private TextMeshProUGUI targetText;

        public void SetAlpha(float alpha)
        {
            if (!TrySetAlpha(alpha))
                Debug.LogWarning("[ToolLab] TmpAlphaFadeIn: No TextMeshProUGUI reference.", this);
        }

        public bool TrySetAlpha(float alpha)
        {
            var tmp = ResolveTarget();
            if (tmp == null)
                return false;

            var clamped = Mathf.Clamp01(alpha);
            var color = tmp.color;
            color.a = clamped;
            tmp.color = color;

            ToolLabWorkLogger.Log(
                ToolId,
                "set_alpha",
                "Alpha set to " + clamped.ToString("F2") + " on " + tmp.name);

            return true;
        }

        public void FadeInImmediate()
        {
            ApplyImmediate(1f, "fade_in_immediate");
        }

        public void FadeOutImmediate()
        {
            ApplyImmediate(0f, "fade_out_immediate");
        }

        private void ApplyImmediate(float alpha, string action)
        {
            var tmp = ResolveTarget();
            if (tmp == null)
            {
                Debug.LogWarning("[ToolLab] TmpAlphaFadeIn: No TextMeshProUGUI reference.", this);
                return;
            }

            var color = tmp.color;
            color.a = alpha;
            tmp.color = color;

            ToolLabWorkLogger.Log(
                ToolId,
                action,
                "Alpha set to " + alpha.ToString("F2") + " on " + tmp.name);
        }

        private TextMeshProUGUI ResolveTarget()
        {
            if (targetText == null)
                targetText = GetComponent<TextMeshProUGUI>();

            return targetText;
        }
    }
}
