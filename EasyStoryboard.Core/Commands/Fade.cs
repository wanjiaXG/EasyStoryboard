using EasyStoryboard.Core.Commands.Base;
using EasyStoryboard.Core.Enums;
using EasyStoryboard.Core.Exceptions;
using System.Collections.Generic;
using static EasyStoryboard.Core.Util;

namespace EasyStoryboard.Core.Commands
{
    public class Fade : SingleCommand
    {
        public Fade() : base(CommandType.Fade) { }

        private float startOpacity = 1.0f;
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
        
        private float endOpacity = 1.0f;
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
            if (opacity < 0.0f ||opacity > 1.0f) throw new OutOfBoundsException(opacity, 0, 1);

            return opacity;
        }

        public override string GetCode()
        {
            return StartOpacity == endOpacity ?
                $"{GetPreCode()},{startOpacity}" :
                $"{GetPreCode()},{startOpacity},{EndOpacity}";
        }

        //_F,(easing),(starttime),(endtime),(start_opacity),(end_opacity)
        public override void LoadCode(string code)
        {
            CheckStrings(code);

            List<string> args = Split(code, ",", true);
            CheckList(args, 5);
            LoadCode(args);
        }

        internal override void LoadCode(List<string> args)
        {
            CheckCommandType(args[0]);

            EasingType = ParseEnum<EasingType>(args[1]);
            StartTime = ParseNumber<int>(args[2]);
            EndTime = ParseNumber<int>(args[3]);
            StartOpacity = ParseNumber<float>(args[4]);

            if (args.Count == 6)
            {
                EndOpacity = ParseNumber<float>(args[5]);
            }
            else
            {
                EndOpacity = StartOpacity;
            }
        }

    }
}
