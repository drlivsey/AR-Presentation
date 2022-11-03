using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARPresentation.Localization
{
    public abstract class BaseLocalizator : MonoBehaviour
    {
        public abstract void ChangeLocalization(string localisation);
    }
}