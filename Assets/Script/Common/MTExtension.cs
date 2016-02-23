﻿using UnityEngine;
using System.Collections;
using System;
using System.Threading;
using System.Collections.Generic;



static class ThreadSafeRandom
{
	[ThreadStatic]
	private static System.Random Local;

	public static System.Random ThisThreadsRandom {
		get { return Local ?? (Local = new System.Random (unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
	}
}

public static class MTRandom
{
	public static void RandomShuffle<T> (this IList<T> list)
	{
		int n = list.Count;
		while (n > 1) {
			n--;
			int k = ThreadSafeRandom.ThisThreadsRandom.Next (n + 1);
			T value = list [k];
			list [k] = list [n];
			list [n] = value;
		}
	}

	static int _flag = 0;
	public static int GetRandomInt()
	{
		_flag++;
		return ThreadSafeRandom.ThisThreadsRandom.Next (_flag);
	}



}
