﻿using System;
namespace Bookman.Models
{
	public interface IOrderRepository
	{
        void CreateOrder(Order order);
    }
}
