Public Class Form1
    Dim OneAcount As New CustomerAccount
    Dim LoanDetails As String = "{0, -18}{1, -18}{2, -18}{3, -18}{4, -18}{5, -18}{6, -16}"
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        hometab.SelectedTab = TabPage1
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        hometab.SelectedTab = TabPage2
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        hometab.SelectedTab = TabPage3
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        hometab.SelectedTab = TabPage4
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim iExit As DialogResult

        iExit = MessageBox.Show("Confirm if you want to exit!", "Bank Loan", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If iExit = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        hometab.SelectedTab = TabPage3
    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click

    End Sub

    Private Sub Btreset_Click(sender As Object, e As EventArgs) Handles Btreset.Click
        txtDAccountNumber.Clear()
        txtCustomerName.Clear()
        txtAmountWithdraw.Clear()
        txtOpeningBal.Clear()
        txtLoan.Clear()
        txtOpeningBal.Clear()
        lblCurrentBalance.Text = ""
        chKloan.Checked = False
    End Sub
    Private Sub btnDeposite_Click(sender As Object, e As EventArgs) Handles btnDeposite.Click

        Dim currentBalance As String

        currentBalance = Val(txtLoan.Text) + Val(txtAmountWithdraw.Text)
        Dim Amount As Decimal
        Amount = txtAmountWithdraw.Text
        OneAcount.Deposit(Amount)
        lblCurrentBalance.Text = Format(OneAcount.CustomerBalance, "Currency")
    End Sub
    Private Sub btnWithdrawal_Click(sender As Object, e As EventArgs) Handles btnWithdrawal.Click
        Dim Amount As Decimal

        Amount = txtAmountWithdraw.Text

        OneAcount.Withdrawal(Amount)
        lblCurrentBalance.Text = Format(OneAcount.CustomerBalance, "Currency")
    End Sub

    Private Sub btnOpenAcount_Click(sender As Object, e As EventArgs) Handles btnOpenAcount.Click
        Dim AccountNumber, name As String
        Dim Balance As Decimal
        Dim Loan As Decimal

        AccountNumber = txtDAccountNumber.Text
        name = txtCustomerName.Text
        Balance = Val(lblCurrentBalance.Text)
        OneAcount.CustomerAccountNumber = AccountNumber
        OneAcount.CustomerName = name
        OneAcount.CustomerBalance = Balance
        Loan = txtLoan.Text


        Balance = Balance - Loan

        If chKloan.Checked = True Then
            Loan = txtLoan.Text
            OneAcount.LoanTaken = True
            OneAcount.CustomerLoan = Loan
        Else
            OneAcount.LoanTaken = False
        End If
        lblCurrentBalance.Text = Format(OneAcount.CustomerBalance, "Currency")
    End Sub

    Private Sub btnDisplay_Click(sender As Object, e As EventArgs) Handles btnDisplay.Click
        Dim Loan As Decimal
        Dim Account_number, Customername, Opening_Balance, currentBalance, Loan_Taken, Amount_of_Loan, Amount_Deposited As String

        If OneAcount.LoanTaken Then
            Loan = OneAcount.CustomerLoan

            Account_number = txtDAccountNumber.Text
            Customername = txtCustomerName.Text
            Opening_Balance = Val(txtOpeningBal.Text)
            currentBalance = Val(txtLoan.Text) - Val(txtAmountWithdraw.Text)
            lblCurrentBalance.Text = currentBalance

            If chKloan.Checked = True Then
                Loan_Taken = "Yes"
            Else
                Loan_Taken = "No"
            End If

            Amount_of_Loan = Format(Loan, "Currency")
            Amount_Deposited = lblCurrentBalance.Text
            Amount_Deposited = Amount_Deposited

            Amount_Deposited = Format(Amount_Deposited, "Currency")
            lstDisplay.Items.Add(String.Format(LoanDetails, Account_number, Customername, Opening_Balance, currentBalance, Loan_Taken, Amount_of_Loan, Amount_Deposited))
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer2.Enabled = True
        lstDisplay.Items.Add(String.Format(LoanDetails, "Account Number", "CustomerName", "Opening Balance", "Current Balance", "Loan Taken", "Amount of Loan", "Amount Deposited"))
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        hometab.SelectedTab = TabPage4
    End Sub

    Private Sub lstClear_Click(sender As Object, e As EventArgs) Handles lstClear.Click
        lstDisplay.Items.Clear()
        lstDisplay.Items.Add(String.Format(LoanDetails, "Account Number", "CustomerName", "Opening Balance", "Current Balance", "Loan Taken", "Amount of Loan", "Amount Deposited"))
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim isave As New SaveFileDialog
        isave.Filter = "txt files (*.txt) |*.txt"

        isave.FilterIndex = 2
        isave.RestoreDirectory = False

        If isave.ShowDialog() = DialogResult.OK Then
            IO.File.WriteAllText(isave.FileName, lstDisplay.Text)
        End If
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        hometab.SelectedTab = TabPage4
    End Sub

    Private Sub txtOpeningBal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOpeningBal.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtLoan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLoan.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub


    Private Sub txtAmountWithdraw_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmountWithdraw.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub lblCurrentBalance_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lblCurrentBalance.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
End Class
