﻿namespace FrameWork.Interfaces.Generic
{
    public interface IRenderable<T>: IRenderable
    {
		T Model { get; set; }
    }
}
