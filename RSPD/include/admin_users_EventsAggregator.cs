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
	public interface IEventProviderCS_admin_users
	{
		//	handlers

		XVar BeforeDelete(dynamic where, dynamic deleted_values, ref dynamic message, dynamic pageObject);


		XVar BeforeAdd(dynamic values, ref dynamic message, dynamic inline, dynamic pageObject);


		XVar AfterAdd(dynamic values, dynamic keys, dynamic inline, dynamic pageObject);


		XVar BeforeInsert(dynamic rawvalues, dynamic values, dynamic pageObject, ref dynamic message);





	}

	public interface IEventProviderVB_admin_users
	{
		//	handlers



	}

	public class eventclass_admin_users : EventsAggregatorBase
	{
		//[Import(typeof(IEventProviderCS_admin_users))]
		public IEventProviderCS_admin_users EventProviderCS;

		//[Import(typeof(IEventProviderVB_admin_users))]
		public IEventProviderVB_admin_users EventProviderVB;

		public void CreateEvents()
        {
			EventProviderCS = new eventclassCS_admin_users();
			if(appsettings.vbEvents != null)
			{
				Type eType = appsettings.vbEvents.GetType("runnerDotNet.runnerDotNet.eventclassVB_admin_users");
				if(eType != null)
				{
					EventProviderVB = (IEventProviderVB_admin_users)Activator.CreateInstance(eType);
				}
			}
        }

		public eventclass_admin_users()
		{
			CreateEvents();

			// fill list of events

			events["BeforeDelete"]=true;


			events["BeforeAdd"]=true;


			events["AfterAdd"]=true;


			events["BeforeInsert"]=true;


		}


		//	handlers

		
		public XVar BeforeDelete(dynamic where, dynamic deleted_values, ref dynamic message, dynamic pageObject)
		{
			return EventProviderCS.BeforeDelete(where, deleted_values, ref message, pageObject);
		}


		
		public XVar BeforeAdd(dynamic values, ref dynamic message, dynamic inline, dynamic pageObject)
		{
			return EventProviderCS.BeforeAdd(values, ref message, inline, pageObject);
		}


		
		public XVar AfterAdd(dynamic values, dynamic keys, dynamic inline, dynamic pageObject)
		{
			return EventProviderCS.AfterAdd(values, keys, inline, pageObject);
		}


		
		public XVar BeforeInsert(dynamic rawvalues, dynamic values, dynamic pageObject, ref dynamic message)
		{
			return EventProviderCS.BeforeInsert(rawvalues, values, pageObject, ref message);
		}





	}
}