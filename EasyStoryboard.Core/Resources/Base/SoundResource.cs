﻿using EasyStoryboard.Core.Common;
using EasyStoryboard.Core.Exceptions;
using EasyStoryboard.Core.Resources.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core.Resources.Base
{
    public abstract class SoundResource : Resource
    {
        public int Offset { set; get; }

        private int _volume;
        public int Volume
        {
            set
            {
                if(value > 100 || value < 0)
                {
                    throw new InvalidValueException("输入的值超出范围");
                }
                Volume = value;
            }
            get
            {
                return _volume;
            }
        }

        public LayerType LayerType { set; get; }

        protected SoundResource(ResourceType type) : base(type) { }

        protected string GetLayerCode(bool optimize)
        {
            return CommonUtil.GetEnumValue(LayerType, optimize);
        }

    }
}