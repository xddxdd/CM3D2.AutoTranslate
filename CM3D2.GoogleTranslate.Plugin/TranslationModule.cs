﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CM3D2.AutoTranslate.Plugin
{

	internal class TranslationData
	{
		public string Text { get; set; }
		public string Translation { get; set; }
		public bool Success { get; set; }
		public int Id { get; set; }
	}

	internal abstract class TranslationModule
	{
		protected abstract string Section { get; }
		public AutoTranslatePlugin _plugin;

		public void LoadConfig()
		{
			var section = CoreUtil.LoadSection(Section);
			LoadConfig(section);
		}
		protected abstract void LoadConfig(CoreUtil.SectionLoader section);

		public abstract bool Init();
		public abstract IEnumerator Translate(TranslationData data);
		public abstract void DeInit();

		public Coroutine StartCoroutine(IEnumerator e)
		{
			return _plugin.StartCoroutine(e);
		}
	}
}