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
	public interface IEventProviderCS_radioequipment
	{
		//	handlers






	}

	public interface IEventProviderVB_radioequipment
	{
		//	handlers



	}

	public class eventclass_radioequipment : EventsAggregatorBase
	{
		//[Import(typeof(IEventProviderCS_radioequipment))]
		public IEventProviderCS_radioequipment EventProviderCS;

		//[Import(typeof(IEventProviderVB_radioequipment))]
		public IEventProviderVB_radioequipment EventProviderVB;

		public void CreateEvents()
        {
			EventProviderCS = new eventclassCS_radioequipment();
			if(appsettings.vbEvents != null)
			{
				Type eType = appsettings.vbEvents.GetType("runnerDotNet.runnerDotNet.eventclassVB_radioequipment");
				if(eType != null)
				{
					EventProviderVB = (IEventProviderVB_radioequipment)Activator.CreateInstance(eType);
				}
			}
        }

		public eventclass_radioequipment()
		{
			CreateEvents();

			// fill list of events



		}


		//	handlers






	}
}