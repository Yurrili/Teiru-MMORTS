﻿using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{
		private Animator _animator;
		private CanvasGroup _canvasGroup;
		public int Menu1 = 5;

		public bool isOpen {
				get { return _animator.GetBool ("IsOpen");}
				set { _animator.SetBool ("IsOpen", value);}
		}

		public void Awake ()
		{
				_animator = GetComponent<Animator> ();
				_canvasGroup = GetComponent<CanvasGroup> ();

				var rect = GetComponent<RectTransform> ();
				rect.offsetMax = rect.offsetMin = new Vector2 (0, 0);
		}

		public void Update ()
		{
				if (!_animator.GetCurrentAnimatorStateInfo (0).IsName ("MainMOpen")) {
						_canvasGroup.blocksRaycasts = _canvasGroup.interactable = false;
				} else {
						_canvasGroup.blocksRaycasts = _canvasGroup.interactable = true;
					
				}

			
		}




}
