Public Class CustomerAccount
    Inherits BankAccount
    Private HasLoan As Boolean
    Private LoanAmount As Decimal

    Public Property CustomerLoan() As Decimal
        Get
            Return LoanAmount
        End Get

        Set(ByVal value As Decimal)
            LoanAmount = value
        End Set
    End Property

    Public Property LoanTaken() As Boolean
        Get
            Return HasLoan
        End Get

        Set(ByVal value As Boolean)
            HasLoan = value
        End Set
    End Property
End Class