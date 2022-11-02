using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARPresentation.Localisation
{
    public abstract class BaseLocalisator : MonoBehaviour
    {
        public abstract void ChangeLocalisation(string localisation);
    }
}