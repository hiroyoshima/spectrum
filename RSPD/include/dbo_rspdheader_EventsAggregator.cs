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
	public interface IEventProviderCS_dbo_rspdheader
	{
		//	handlers

		XVar BeforeAdd(dynamic values, ref dynamic message, dynamic inline, dynamic pageObject);


		XVar BeforeEdit(dynamic values, dynamic where, dynamic oldvalues, dynamic keys, ref dynamic message, dynamic inline, dynamic pageObject);


		XVar BeforeDelete(dynamic where, dynamic deleted_values, ref dynamic message, dynamic pageObject);




		XVar ProcessValuesAdd(dynamic values, dynamic pageObject);





	}

	public interface IEventProviderVB_dbo_rspdheader
	{
		//	handlers



	}

	public class eventclass_dbo_rspdheader : EventsAggregatorBase
	{
		//[Import(typeof(IEventProviderCS_dbo_rspdheader))]
		public IEventProviderCS_dbo_rspdheader EventProviderCS;

		//[Import(typeof(IEventProviderVB_dbo_rspdheader))]
		public IEventProviderVB_dbo_rspdheader EventProviderVB;

		public void CreateEvents()
        {
			EventProviderCS = new eventclassCS_dbo_rspdheader();
			if(appsettings.vbEvents != null)
			{
				Type eType = appsettings.vbEvents.GetType("runnerDotNet.runnerDotNet.eventclassVB_dbo_rspdheader");
				if(eType != null)
				{
					EventProviderVB = (IEventProviderVB_dbo_rspdheader)Activator.CreateInstance(eType);
				}
			}
        }

		public eventclass_dbo_rspdheader()
		{
			CreateEvents();

			// fill list of events

			events["BeforeAdd"]=true;


			events["BeforeEdit"]=true;


			events["BeforeDelete"]=true;




			events["ProcessValuesAdd"]=true;


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




		
		public XVar ProcessValuesAdd(dynamic values, dynamic pageObject)
		{
			return EventProviderCS.ProcessValuesAdd(values, pageObject);
		}





	}
}