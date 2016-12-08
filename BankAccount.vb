Public Class BankAccount

    Private AccountNumber, Name As String
    Private Balance As Decimal

    Public WriteOnly Property CustomerAccountNumber() As String
        Set(ByVal Value As String)
            AccountNumber = Value
        End Set
    End Property

    Public WriteOnly Property CustomerName() As String
        Set(ByVal Value As String)
            Name = Value
        End Set
    End Property

    Public Property CustomerBalance() As Decimal
        Get
            Return Balance
        End Get
        Set(ByVal Value As Decimal)

        End Set
    End Property

    Public Sub Deposit(ByVal Amount As Decimal)
        Balance = Balance + Amount
    End Sub

    Public Sub Withdrawal(ByVal Amount As Decimal)
        Balance = Balance - Amount
    End Sub
End Class
