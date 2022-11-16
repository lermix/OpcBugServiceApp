using OpcLabs.EasyOpc.UA;
using OpcLabs.EasyOpc.UA.AddressSpace.Standard;
using OpcLabs.EasyOpc.UA.AlarmsAndConditions;
using OpcLabs.EasyOpc.UA.OperationModel;
using System;
using System.Diagnostics;
using System.IO;

namespace OpcLabsBugWindowService
{
	public class Client
	{
		private static EasyUAClient client;
		private static bool EventCollectionStarted = false;

		public static void Start()
		{
			UAEndpointDescriptor endpointDescriptor = new UAEndpointDescriptor( "opc.tcp://localhost:50000" );
			client = new EasyUAClient();

			client.EventNotification += Client_EventNotification;
			UAAttributeFieldCollection uAAttributeFields = UABaseEventObject.AllFields;
			int eventMonitoredItem = client.SubscribeEvent(
				endpointDescriptor,
				UAObjectIds.Server,
				0,
				uAAttributeFields );
		}

		private static void Client_EventNotification( object sender, EasyUAEventNotificationEventArgs e )
		{
			if ( e.EventData == null )
				return;

			if ( !EventCollectionStarted )
			{
				EventCollectionStarted = true;
				if ( Directory.Exists( @"C:\OpcTest" ) )
					Directory.CreateDirectory( @"C:\OpcTest" );

				File.WriteAllText( @"C:\OpcTest\EventsStarted.txt", "Opc test, Event collecting started" );
			}

			var Time = Convert.ToDateTime( e.EventData.FieldResults[UABaseEventObject.Operands.Time].Value ).ToLocalTime();
			var EventText = e.EventData.FieldResults[UABaseEventObject.Operands.Message].Value.ToString();
		}
	}
}
