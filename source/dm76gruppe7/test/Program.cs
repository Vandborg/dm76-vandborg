using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessTier;
using DataTier;
using DBLayer;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;
using System.IO;

namespace test
{
    class Program
    {
        //static IRouteplanner rp = new RoutePlanner();
        static void Main(string[] args)
        {
            /*Node testNode1 = new Node(new Station("Løkkegade", "27, 3. th.", 9000));
            Node testNode2 = new Node(new Station("Løkkegade", "28, 3. th.", 9000));

            Graph graph1 = rp.getGraph();
            Graph graph2 = rp.getGraph().DeepClone();

            graph2.AddNode(testNode1);
            graph2.AddNode(testNode2);

            //List<Node> result =  graph.ShortestPath(testNode1, testNode2);
            /*List<Node> result = graph1.ShortestPath(graph1.Nodes.ElementAt(0), graph1.Nodes.ElementAt(5));

            //Console.WriteLine(result.Count.ToString());
           
           foreach (Node n in result)
           {
               Console.WriteLine(n.Data._street+" "+n.Data._streetNo);
           }

            foreach (Node n in graph1.Nodes)
            {
                Console.WriteLine(n.Data._street + " " + n.Data._streetNo);
            }

           Console.WriteLine("------------------------------------------------");

           /*result = graph2.ShortestPath(graph2.Nodes.ElementAt(0), graph2.Nodes.ElementAt(5));

           Console.WriteLine(result.Count.ToString());

           foreach (Node n in result)
           {
               Console.WriteLine(n.Data._street + " " + n.Data._streetNo);
           }

           foreach (Node n in graph2.Nodes)
           {
               Console.WriteLine(n.Data._street + " " + n.Data._streetNo);
           }

           Console.ReadLine();*/

            /*IDBBattery dbbattery = new DBBattery();
            Battery battery = new Battery(Battery.Status.Charged,new Station(1,"TRAFIKCENTER SÆBY SYD","20",9300));

            if (dbbattery.createBattery(battery))
            {
                Console.WriteLine("Battery created in database");
                List<Battery> batteries = dbbattery.getAllBatteries();
                Console.WriteLine("-------------The new battery------------");
                Console.WriteLine("ID: "+batteries.Last()._id.ToString());
                Console.WriteLine("StationID: "+batteries.Last()._station._id.ToString());
                Console.WriteLine("Status: "+batteries.Last()._status.ToString());
                Console.WriteLine("----------------------------------------");

                batteries.Last()._station = null;
                batteries.Last()._status = Battery.Status.Booked;

                if(dbbattery.updateBattery(batteries.Last()))
                {
                    Console.WriteLine("Battery updated in database");
                    List<Battery> batteries2 = dbbattery.getAllBatteries();
                    Console.WriteLine("----------The updated battery------------");
                    Console.WriteLine("ID: " + batteries2.Last()._id.ToString());
                    //Console.WriteLine("StationID: " + batteries2.Last()._station.ToString());
                    Console.WriteLine("Status: " + batteries2.Last()._status.ToString());
                    Console.WriteLine("----------------------------------------");
                    if(dbbattery.deleteBattery(batteries.Last()))
                    {
                        Console.WriteLine("Battery deleted in database");
                        List<Battery> batteries3 = dbbattery.getAllBatteries();
                        Console.WriteLine("----------The remaining batteries------------");
                        foreach (Battery battery1 in batteries3)
                        {
                            Console.WriteLine("ID: " + battery1._id.ToString());
                            //Console.WriteLine("StationID: " + batteries3.Last()._station.ToString());
                            Console.WriteLine("Status: " + battery1._status.ToString());
                        }
                        Console.WriteLine("----------------------------------------");
                    }
                }
            }*/

            /*IDBCar dbcar = new DBCar();
            Car car = new Car("dd12319",150,new Customer(1,"Jesper Vandborg","jesper@vandborg.net"));

            if (dbcar.createCar(car))
            {
                Console.WriteLine("Car created in database");
                List<Car> Cars = dbcar.getAllCars();
                Console.WriteLine("-------------The new car------------");
                Console.WriteLine("ID: " + Cars.Last()._id.ToString());
                Console.WriteLine("LicensPlate: " + Cars.Last()._licensPlate);
                Console.WriteLine("Range: " + Cars.Last()._range);
                Console.WriteLine("CustomerID : " + Cars.Last()._customer._id.ToString());
                Console.WriteLine("----------------------------------------");

                Cars.Last()._range = 100;

                if (dbcar.updateCar(Cars.Last()))
                {
                    Console.WriteLine("Car updated in database");
                    List<Car> Cars2 = dbcar.getAllCars();
                    Console.WriteLine("----------The updated car------------");
                    Console.WriteLine("ID: " + Cars2.Last()._id.ToString());
                    Console.WriteLine("LicensPlate: " + Cars2.Last()._licensPlate);
                    Console.WriteLine("Range: " + Cars2.Last()._range);
                    Console.WriteLine("CustomerID : " + Cars2.Last()._customer._id.ToString());
                    Console.WriteLine("----------------------------------------");
                    if (dbcar.deleteCar(Cars2.Last()))
                    {
                        Console.WriteLine("Car deleted in database");
                        List<Car> Cars3 = dbcar.getAllCars();
                        Console.WriteLine("----------The remaining cars------------");
                        foreach (Car car1 in Cars3)
                        {
                            Console.WriteLine("ID: " + car1._id.ToString());
                            Console.WriteLine("LicensPlate: " + car1._licensPlate);
                            Console.WriteLine("Range: " + car1._range);
                            Console.WriteLine("CustomerID : " + car1._customer._id.ToString());
                        }
                        Console.WriteLine("----------------------------------------");
                    }
                }
            }*/

            /*IDBCustomer dbCustomer = new DBCustomer();
            Customer Customer = new Customer("Charlotte Bust Sigvardt", "charlottebust@gmail.com");

            if (dbCustomer.createCustomer(Customer))
            {
                Console.WriteLine("Customer created in database");
                List<Customer> Customers = dbCustomer.getAllCustomers();
                Console.WriteLine("-------------The new Customer------------");
                Console.WriteLine("ID: " + Customers.Last()._id.ToString());
                Console.WriteLine("Name: " + Customers.Last()._name);
                Console.WriteLine("Email: " + Customers.Last()._email);
                Console.WriteLine("----------------------------------------");

                Customers.Last()._name = "Niels Hansen";
                Customers.Last()._email = "something@google.com";

                if (dbCustomer.updateCustomer(Customers.Last()))
                {
                    Console.WriteLine("Customer updated in database");
                    List<Customer> Customers2 = dbCustomer.getAllCustomers();
                    Console.WriteLine("----------The updated Customer------------");
                    Console.WriteLine("ID: " + Customers2.Last()._id.ToString());
                    Console.WriteLine("Name: " + Customers2.Last()._name);
                    Console.WriteLine("Email: " + Customers2.Last()._email);
                    Console.WriteLine("----------------------------------------");
                    if (dbCustomer.deleteCustomer(Customers2.Last()))
                    {
                        Console.WriteLine("Customer deleted in database");
                        List<Customer> Customers3 = dbCustomer.getAllCustomers();
                        Console.WriteLine("----------The remaining Customers------------");
                        foreach (Customer Customer1 in Customers3)
                        {
                            Console.WriteLine("ID: " + Customer1._id.ToString());
                            Console.WriteLine("Name: " + Customer1._name);
                            Console.WriteLine("Email: " + Customer1._email);
                        }
                        Console.WriteLine("----------------------------------------");
                    }
                }
            }*/

            /*IDBLocation dbLocation = new DBLocation();
            Location Location = new Location("Løkkegade","21 3. th.",9000);

            if (dbLocation.createLocation(Location))
            {
                Console.WriteLine("Location created in database");
                List<Location> Locations = dbLocation.getAllLocations();
                Console.WriteLine("-------------The new Location------------");
                Console.WriteLine("ID: " + Locations.Last()._id.ToString());
                Console.WriteLine("Street: " + Locations.Last()._street);
                Console.WriteLine("StreetNo: " + Locations.Last()._streetNo);
                Console.WriteLine("ZipCode: " + Locations.Last()._zipCode.ToString());
                Console.WriteLine("----------------------------------------");

                Locations.Last()._street = "Danmarksgade";
                Locations.Last()._streetNo = "61, 1.";

                if (dbLocation.updateLocation(Locations.Last()))
                {
                    Console.WriteLine("Location updated in database");
                    List<Location> Locations2 = dbLocation.getAllLocations();
                    Console.WriteLine("----------The updated Location------------");
                    Console.WriteLine("ID: " + Locations2.Last()._id.ToString());
                    Console.WriteLine("Street: " + Locations2.Last()._street);
                    Console.WriteLine("StreetNo: " + Locations2.Last()._streetNo);
                    Console.WriteLine("ZipCode: " + Locations2.Last()._zipCode.ToString());
                    Console.WriteLine("----------------------------------------");
                    if (dbLocation.deleteLocation(Locations2.Last()))
                    {
                        Console.WriteLine("Location deleted in database");
                        List<Location> Locations3 = dbLocation.getAllLocations();
                        Console.WriteLine("----------The remaining Locations------------");
                        foreach (Location Location1 in Locations3)
                        {
                            Console.WriteLine("ID: " + Location1._id.ToString());
                            Console.WriteLine("Street: " + Location1._street);
                            Console.WriteLine("StreetNo: " + Location1._streetNo);
                            Console.WriteLine("ZipCode: " + Location1._zipCode.ToString());
                        }
                        Console.WriteLine("----------------------------------------");
                    }
                }
            }*/

            IDBStation dbStation = new DBStation();
            Station Station = new Station("Løkkegade", "21 3. th.", 9000);

            if (dbStation.createStation(Station))
            {
                Console.WriteLine("Station created in database");
                List<Station> Stations = dbStation.getAllStations();
                Console.WriteLine("-------------The new Station------------");
                Console.WriteLine("ID: " + Stations.Last()._id.ToString());
                Console.WriteLine("Street: " + Stations.Last()._street);
                Console.WriteLine("StreetNo: " + Stations.Last()._streetNo);
                Console.WriteLine("ZipCode: " + Stations.Last()._zipCode.ToString());
                Console.WriteLine("----------------------------------------");

                Stations.Last()._street = "Danmarksgade";
                Stations.Last()._streetNo = "61, 1.";

                if (dbStation.updateStation(Stations.Last()))
                {
                    Console.WriteLine("Station updated in database");
                    List<Station> Stations2 = dbStation.getAllStations();
                    Console.WriteLine("----------The updated Station------------");
                    Console.WriteLine("ID: " + Stations2.Last()._id.ToString());
                    Console.WriteLine("Street: " + Stations2.Last()._street);
                    Console.WriteLine("StreetNo: " + Stations2.Last()._streetNo);
                    Console.WriteLine("ZipCode: " + Stations2.Last()._zipCode.ToString());
                    Console.WriteLine("----------------------------------------");
                    if (dbStation.deleteStation(Stations2.Last()))
                    {
                        Console.WriteLine("Station deleted in database");
                        List<Station> Stations3 = dbStation.getAllStations();
                        Console.WriteLine("----------The remaining Stations------------");
                        foreach (Station Station1 in Stations3)
                        {
                            Console.WriteLine("ID: " + Station1._id.ToString());
                            Console.WriteLine("Street: " + Station1._street);
                            Console.WriteLine("StreetNo: " + Station1._streetNo);
                            Console.WriteLine("ZipCode: " + Station1._zipCode.ToString());
                        }
                        Console.WriteLine("----------------------------------------");
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
