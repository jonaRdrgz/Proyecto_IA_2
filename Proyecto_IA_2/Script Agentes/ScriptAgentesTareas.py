import random

listaTareas = ["ICE", "ICG", "ICG", "ILA", "RCE", "RCG","RLA"];

def escribirEsqueletoXMLAgentes(archivo):
        archivo.write("<?xml version='1.0' encoding='utf-8' ?>\n")
        archivo.write("<Agents>\n")

        
def escribirArchivoXMLAgentes(archivo, nombreAgente, listaServicios, idAgente):
        archivo.write("\t<Agent ID ='%d'  Name ='%s'>\n" %(idAgente,nombreAgente[:-1]) )
        for servicio in listaServicios:
                 archivo.write("\t\t<Service Code ='%s'/>\n " % servicio)
        archivo.write('\t</Agent>\n')
def escribirEsqueletoXMLTareas(archivo):
        archivo.write("<?xml version='1.0' encoding='utf-8' ?>\n")
        archivo.write("<RequestedServices>\n")

        
def escribirArchivoXMLTareas(archivo, nombreCustomer, service, idTarea):
        archivo.write("\t<RequestedService ID ='%d'>\n" %(idTarea) )
        archivo.write("\t\t<Customer Name ='%s'/>\n " % nombreCustomer[:-1])
        archivo.write("\t\t<Service Code ='%s'/>\n " % service)
        archivo.write('\t</RequestedService>\n')
        
def getListaTareas(n):
        listaTareasSeleccionadas = []
        for i in range(n):
                elementoAAgregar =  listaTareas[random.randrange(len(listaTareas))]
                while elementoAAgregar  in listaTareasSeleccionadas:
                        elementoAAgregar =  listaTareas[random.randrange(len(listaTareas))]
                listaTareasSeleccionadas.append(elementoAAgregar);
        return listaTareasSeleccionadas;

def crearAgentes():
        archivoNombreAgentes = open("NombresAgentes.txt", "r")
        archivoNombreAgentesXML = open("NombresAgentesXML.xml", "a")
        escribirEsqueletoXMLAgentes(archivoNombreAgentesXML)
        idAgente = 1
        for nombre in archivoNombreAgentes.readlines():
                
                escribirArchivoXMLAgentes(archivoNombreAgentesXML,nombre,getListaTareas(random.randrange(len(listaTareas))), idAgente)
                idAgente += 1
        archivoNombreAgentesXML.write("<Agents>\n")
        archivoNombreAgentes.close()
        archivoNombreAgentesXML.close()

def crearTareas():
        archivoNombreCustomer = open("NombreCustomer.txt", "r")
        archivoNombreCustomerXML = open("NombreCustomerXML.xml", "a")
        escribirEsqueletoXMLTareas(archivoNombreCustomerXML)
        idTarea = 1
        for nombre in archivoNombreCustomer.readlines():
                escribirArchivoXMLTareas(archivoNombreCustomerXML,nombre,listaTareas[random.randrange(len(listaTareas))], idTarea)
                idTarea += 1
        archivoNombreCustomerXML.write("<RequestedServices>\n")
        archivoNombreCustomer.close()
        archivoNombreCustomerXML.close()
    


