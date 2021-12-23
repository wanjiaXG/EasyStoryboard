using EasyStoryboard.Core.Commands.Base;
using System;
using System.Collections.Generic;

using static EasyStoryboard.Core.Commons.CommonUtil;

namespace EasyStoryboard.Core.Commands
{
    public class Fade : BaseCommand
    {
        public Fade() : base(Enums.CommandType.Fade) { }

        private float startOpacity = 1;
        public float StartOpacity
        {
            set
            {
                startOpacity = CheckOpacity(value);
            }
            get
            {
                return startOpacity;
            }
        }
        private float endOpacity = 1;
        public float EndOpacity
        {
            set
            {
                endOpacity = CheckOpacity(value);
            }
            get
            {
                return endOpacity;
            }
        }

        private float CheckOpacity(float opacity)
        {
            if (opacity < 0.0f)
            {
                opacity = 0.0f;
            }
            else if (opacity > 1.0f)
            {
                opacity = 1.0f;
            }
            return opacity;
        }


        public override string GetCode()
        {
            return StartOpacity == endOpacity ?
                $"{base.GetCode()},{startOpacity}" :
                $"{base.GetCode()},{startOpacity},{EndOpacity}";
        }

        //_F,(easing),(starttime),(endtime),(start_opacity),(end_opacity)
        public override void LoadCode(string code)
        {
            CheckStrings(code);

            List<string> list = Split(code, ",", true);
            
            if(list.Count == 5 || list.Count == 6)
            {
                CheckCommandType(list[0]);
                SetEasingType(list[1]);
                SetStartTime(list[2]);
                SetEndTime(list[3]);
                SetStartOpacity(list[4]);
                if (list.Count == 6)
                {
                    SetEndOpacity(list[5]);
                }
                else
                {
                    EndOpacity = StartOpacity;
                }
            }
            else
            {
                throw new ArgumentException("Code format error.");
            }
        }

        private void SetEndOpacity(string value)
        {
            if (float.TryParse(value, out float startOpacity))
            {
                EndOpacity = startOpacity;
            }
            else
            {
                throw new ArgumentException("End opacity is not number.");
            }
        }

        protected void SetStartOpacity(string value)
        {
            if (float.TryParse(value, out float startOpacity))
            {
                StartOpacity = startOpacity;
            }
            else
            {
                throw new ArgumentException("Start opacity is not number.");
            }
        }

    }
}
