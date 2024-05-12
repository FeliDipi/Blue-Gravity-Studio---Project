using System.Collections.Generic;
using UnityEngine;

namespace BGS.Apparence
{
    public interface IApparenceApplicator
    {
        public ApparenceType Key { get; }

        public List<Sprite> Frames { get; }

        public void SetFrame(int frame);

        public void SetFrames(List<Sprite> frames);
    }
}

