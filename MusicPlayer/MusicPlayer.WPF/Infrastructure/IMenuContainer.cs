﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.WPF.Infrastructure
{
    public interface IMenuContainer
    {
        void CollapseMenu();
        void ExpendMenu();
    }
}
