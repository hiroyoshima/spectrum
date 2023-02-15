using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Dynamic;
using System.ComponentModel.Composition;
using runnerDotNet;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Web;
using System.Reflection;

namespace runnerDotNet
{
	public interface IEventProviderCS_delivery_unit
	{
		//	handlers

		XVar BeforeAdd(dynamic values, ref dynamic message, dynamic inline, dynamic pageObject);





	}

	public interface IEventProviderVB_delivery_unit
	{
		//	handlers



	}

	public class eventclass_delivery_unit : EventsAggregatorBase
	{
		//[Import(typeof(IEventProviderCS_delivery_unit))]
		public IEventProviderCS_delivery_unit EventProviderCS;

		//[Import(typeof(IEventProviderVB_delivery_unit))]
		public IEventProviderVB_delivery_unit EventProviderVB;

		public void CreateEvents()
        {
			EventProviderCS = new eventclassCS_delivery_unit();
			if(appsettings.vbEvents != null)
			{
				Type eType = appsettings.vbEvents.GetType("runnerDotNet.runnerDotNet.eventclassVB_delivery_unit");
				if(eType != null)
				{
					EventProviderVB = (IEventProviderVB_delivery_unit)Activator.CreateInstance(eType);
				}
			}
        }

		public eventclass_delivery_unit()
		{
			CreateEvents();

			// fill list of events

			events["BeforeAdd"]=true;


		}


		//	handlers

		
		public XVar BeforeAdd(dynamic values, ref dynamic message, dynamic inline, dynamic pageObject)
		{
			return EventProviderCS.BeforeAdd(values, ref message, inline, pageObject);
		}





	}
}