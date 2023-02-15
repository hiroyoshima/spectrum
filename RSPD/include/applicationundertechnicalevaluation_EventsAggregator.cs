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
	public interface IEventProviderCS_applicationundertechnicalevaluation
	{
		//	handlers

		XVar BeforeEdit(dynamic values, dynamic where, dynamic oldvalues, dynamic keys, ref dynamic message, dynamic inline, dynamic pageObject);


		XVar BeforeDelete(dynamic where, dynamic deleted_values, ref dynamic message, dynamic pageObject);







	}

	public interface IEventProviderVB_applicationundertechnicalevaluation
	{
		//	handlers



	}

	public class eventclass_applicationundertechnicalevaluation : EventsAggregatorBase
	{
		//[Import(typeof(IEventProviderCS_applicationundertechnicalevaluation))]
		public IEventProviderCS_applicationundertechnicalevaluation EventProviderCS;

		//[Import(typeof(IEventProviderVB_applicationundertechnicalevaluation))]
		public IEventProviderVB_applicationundertechnicalevaluation EventProviderVB;

		public void CreateEvents()
        {
			EventProviderCS = new eventclassCS_applicationundertechnicalevaluation();
			if(appsettings.vbEvents != null)
			{
				Type eType = appsettings.vbEvents.GetType("runnerDotNet.runnerDotNet.eventclassVB_applicationundertechnicalevaluation");
				if(eType != null)
				{
					EventProviderVB = (IEventProviderVB_applicationundertechnicalevaluation)Activator.CreateInstance(eType);
				}
			}
        }

		public eventclass_applicationundertechnicalevaluation()
		{
			CreateEvents();

			// fill list of events

			events["BeforeEdit"]=true;


			events["BeforeDelete"]=true;




		}


		//	handlers

		
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