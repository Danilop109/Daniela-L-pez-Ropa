# Ske-Project


## Endpoints Especificos ⌨️

❗ Recordar que en cada consulta encontramos dos versiones. La `1.0`, la cual responde correctamente la informacion requerida y la `1.1`, la cual nos responde con la informacion pero en esta ocasion implementando la paginación.

🕹 Para consultar la versión 1.0 de todos se ingresa únicamente el Endpoint; para consultar la versión 1.1 se deben seguir los siguientes pasos: 

En el Thunder Client se va al apartado de "Headers" y se escribes lo siguiente: `X-Version` con la version 1.1.

![image](https://github.com/Danilop109/Backend-Vet/assets/124645738/c42e2861-0386-422a-8146-9093c97319f7)

Para modificar la paginación vas al apartado de "Query" y se ingresa lo siguiente:

![image](https://github.com/SilviaJaimes/Proyecto-Veterinaria/assets/132016483/22683e46-037e-4f30-96b8-161df8622b40)

 ⚠️ - Recuerda tener un token e implementarlo en Auth.
 ![image](https://github.com/Danilop109/Backend-Vet/assets/124645738/43cb1ba6-9cf1-4999-a596-45ba5bd811dc)

## Grupo A-1. Visualizar los veterinarios cuya especialidad sea Cirujano vascular:

    **Endpoint**: `http://localhost:5159/api/Veterinario/GetCirujanoVascular`
    
    **Método**: `GET`


## Grupo A-2. Listar los medicamentos que pertenezcan a el laboratorio Genfar:

**Endpoint**: `http://localhost:5159/api/Medicamento/GetMediFromLab`

**Método**: `GET`


## Grupo A-3. Mostrar las mascotas que se encuentren registradas cuya especie sea felina:

**Endpoint**: `http://localhost:5159/api/Mascota/GetPetEspecie`

**Método**: `GET`


## Grupo A-4. Listar los propietarios y sus mascotas:

**Endpoint**: `http://localhost:5159/api/Propietario/GetPetPer`

**Método**: `GET`


## Grupo A-5. Listar los medicamentos que tenga un precio de venta mayor a 50000:

**Endpoint**: `http://localhost:5159/api/Medicamento/GetMedi50000`

**Método**: `GET`


## Grupo A-6. Listar las mascotas que fueron atendidas por motivo de vacunacion en el primer trimestre del 2023:

**Endpoint**: `http://localhost:5159/api/Cita/GetPetMotiveDate`

**Método**: `GET`


## Grupo B-1. Listar todas las mascotas agrupadas por especie:

**Endpoint**: `http://localhost:5159/api/Mascota/GetPetGropuByEspe`

**Método**: `GET`


## Grupo B-2. Listar todos los movimientos de medicamentos y el valor total de cada movimiento:

**Endpoint**: `http://localhost:5159/api/MovimientoMedicamento/GetmoviMedi`

**Método**: `GET`


## Grupo B-3. Listar las mascotas que fueron atendidas por un determinado veterinario:

**Endpoint**: `http://localhost:5159/api/Mascota/GetPetForVet`

**Método**: `GET`

## Grupo B-4. Listar los proveedores que me venden un determinado medicamento:

**Endpoint**: `http://localhost:5159/api/MedicamentoProveedor/GetProveeSaleMedi`

**Método**: `GET`

## Grupo B-5. Listar las mascotas y sus propietarios cuya raza sea Golden Retriver:

**Endpoint**: `http://localhost:5159/api/Mascota/GetPetProRazaGoldenRetriever`

**Método**: `GET`

## Grupo B-6. Listar la cantidad de mascotas que pertenecen a una raza:

**Endpoint**: `http://localhost:5159/api/Raza/GetPetsByRaza`

**Método**: `GET`

## Agradecimientos

¡Gracias por usar este proyecto! Si tienes alguna pregunta o sugerencia, no dudes en ponerte en contacto con la creadora.
Con cariño Daniela López.