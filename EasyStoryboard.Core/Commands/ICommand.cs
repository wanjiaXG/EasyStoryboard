using EasyStoryboard.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core.Commands
{
    public interface ICommand
    {
        string GetCode();

        void LoadCode(string code);

        string GetHeader();

    }
}
