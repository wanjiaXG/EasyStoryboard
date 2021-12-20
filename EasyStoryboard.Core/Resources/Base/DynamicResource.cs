﻿using EasyStoryboard.Core.Commands.Base;
using EasyStoryboard.Core.Commons;
using EasyStoryboard.Core.Resources.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core.Resources.Base
{
    public abstract class DynamicResource : GraphicsResource
    {
        public LayerType LayerType { set; get; }

        public OriginType OriginType { set; get; }

        List<Command> Commands { get; } = new List<Command>();

        internal DynamicResource(ResourceType type, string filePath) : base(type, filePath) { }
    }
}
