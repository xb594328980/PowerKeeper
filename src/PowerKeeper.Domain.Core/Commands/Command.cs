﻿using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerKeeper.Domain.Core.Commands
{
    /// <summary>
    /// 抽象命令基类
    /// <remarks>create by xingbo 18/12/17</remarks>
    /// </summary>
    public abstract class Command : IRequest
    {
        //时间戳
        public DateTime Timestamp { get; private set; }
        //验证结果，需要引用FluentValidation
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        //定义抽象方法，是否有效
        public abstract bool IsValid();
    }
}
