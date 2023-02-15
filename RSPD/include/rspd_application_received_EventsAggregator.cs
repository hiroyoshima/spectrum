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
	public interface IEventProviderCS_rspd_application_received
	{
		//	handlers

		XVar BeforeAdd(dynamic values, ref dynamic message, dynamic inline, dynamic pageObject);


		XVar BeforeEdit(dynamic values, dynamic where, dynamic oldvalues, dynamic keys, ref dynamic message, dynamic inline, dynamic pageObject);


		XVar BeforeDelete(dynamic where, dynamic deleted_values, ref dynamic message, dynamic pageObject);







	}

	public interface IEventProviderVB_rspd_application_received
	{
		//	handlers



	}

	public class eventclass_rspd_application_received : EventsAggregatorBase
	{
		//[Import(typeof(IEventProviderCS_rspd_application_received))]
		public IEventProviderCS_rspd_application_received EventProviderCS;

		//[Import(typeof(IEventProviderVB_rspd_application_received))]
		public IEventProviderVB_rspd_application_received EventProviderVB;

		public void CreateEvents()
        {
			EventProviderCS = new eventclassCS_rspd_application_received();
			if(appsettings.vbEvents != null)
			{
				Type eType = appsettings.vbEvents.GetType("runnerDotNet.runnerDotNet.eventclassVB_rspd_application_received");
				if(eType != null)
				{
					EventProviderVB = (IEventProviderVB_rspd_application_received)Activator.CreateInstance(eType);
				}
			}
        }

		public eventclass_rspd_application_received()
		{
			CreateEvents();

			// fill list of events

			events["BeforeAdd"]=true;


			events["BeforeEdit"]=true;


			events["BeforeDelete"]=true;




		}


		//	handlers

		
		public XVar BeforeAdd(dynamic values, ref dynamic message, dynamic inline, dynamic pageObject)
		{
			return EventProviderCS.BeforeAdd(values, ref message, inline, pageObject);
		}


		
		public XVar BeforeEdit(dynamic values, dynamic where, dynamic oldvalues, dynamic keys, ref dynamic message, dynamic inline, dynamic pageObject)
		{
			return EventProviderCS.BeforeEdit(values, where, oldvalues, keys, ref message, inline, pageObject);
		}


		
		public XVar BeforeDelete(dynamic where, dynamic deleted_values, ref dynamic message, dynamic pageObject)
		{
			return EventProviderCS.BeforeDelete(where, deleted_values, ref message, pageObject);
		}







	}
}