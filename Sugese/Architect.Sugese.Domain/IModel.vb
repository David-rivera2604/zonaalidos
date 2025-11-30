Imports System.ServiceModel

<ServiceContract()>
Public Interface IModel

    <OperationContract()>
    Function Enviar(archivo As String, ByVal nombreModelo As String, ByVal anno As Integer, ByVal periodo As Integer) As String

End Interface
