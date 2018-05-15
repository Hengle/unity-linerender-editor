﻿#region statement
/*************************************************************************************   
    * 作    者：       zouhunter
    * 时    间：       2018-05-14 01:43:33
    * 说    明：       
* ************************************************************************************/
#endregion
using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
namespace SpaceLine.Common
{
    /// <summary>
    /// 点
    /// <summary>
    public sealed class PointBehaiver : ContentBehaiver,IPointBehaiver
    {
        private float diameter = 1;
        public Point Info { get; private set; }
        public UnityAction<PointBehaiver> onHover { get; set; }
        public UnityAction<PointBehaiver> onClicked { get; set; }
        
        private void Awake()
        {
            gameObject.layer = LayerMask.NameToLayer("SpaceLine_point");
            SetSize(2);
        }
        internal void OnInitialized(Point node)
        {
            this.Info = node;
            transform.localPosition = Info.position;
            CreateCollider();
        }

        private void OnMouseUp()
        {
            if (onClicked != null && !IsMousePointOnUI() && this == hoverItem)
            {
                onClicked.Invoke(this);
            }
        }

        protected override void OnMouseOver()
        {
            base.OnMouseOver();
            if (onHover != null && !IsMousePointOnUI())
                onHover.Invoke(this);
        }

        private void SetSize(float r_node)
        {
            diameter = 2 * r_node;
            transform.localScale = Vector3.one * diameter;
        }
    }
}