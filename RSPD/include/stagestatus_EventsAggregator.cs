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
	public interface IEventProviderCS_stagestatus
	{
		//	handlers

		XVar BeforeDelete(dynamic where, dynamic deleted_values, ref dynamic message, dynamic pageObject);





	}

	public interface IEventProviderVB_stagestatus
	{
		//	handlers



	}

	public class eventclass_stagestatus : EventsAggregatorBase
	{
		//[Import(typeof(IEventProviderCS_stagestatus))]
		public IEventProviderCS_stagestatus EventProviderCS;

		//[Import(typeof(IEventProviderVB_stagestatus))]
		public IEventProviderVB_stagestatus EventProviderVB;

		public void CreateEvents()
        {
			EventProviderCS = new eventclassCS_stagestatus();
			if(appsettings.vbEvents != null)
			{
				Type eType = appsettings.vbEvents.GetType("runnerDotNet.runnerDotNet.eventclassVB_stagestatus");
				if(eType != null)
				{
					EventProviderVB = (IEventProviderVB_stagestatus)Activator.CreateInstance(eType);
				}
			}
        }

		public eventclass_stagestatus()
		{
			CreateEvents();

			// fill list of events

			events["BeforeDelete"]=true;


		}


		//	handlers

		
		public XVar BeforeDelete(dynamic where, dynamic deleted_values, ref dynamic message, dynamic pageObject)
		{
			return EventProviderCS.BeforeDelete(where, deleted_values, ref message, pageObject);
		}





	}
}