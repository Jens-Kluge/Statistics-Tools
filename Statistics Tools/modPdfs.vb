Imports MathNet.Numerics

Module modPdfs
    Public Function WeibullPdf(a As Double, b As Double, x As Double) As Double
        'alpha, beta must positive
        'or raise exception
        If a <= 0 Or b <= 0 Then
            Return -1
        End If

        If x < 0 Then
            WeibullPdf = 0
        Else
            WeibullPdf = (b / a) * (x / a) ^ (b - 1) * Math.Exp(-(x / a) ^ b)
        End If
    End Function

    Public Function GammaPdf(g As Double, mu As Double, b As Double, x As Double)
        GammaPdf = ((x - mu) / b) ^ (g - 1) * Math.Exp(-(x - mu) / b) / (b * SpecialFunctions.Gamma(g))
    End Function

    Public Function ChiSquarePdf(k As Integer, x As Double)

        If x < 0 Then
            ChiSquarePdf = 0
        Else
            ChiSquarePdf = x ^ (k / 2 - 1) * Math.Exp(-x / 2) / (2 ^ (k / 2) * SpecialFunctions.Gamma(k / 2))
        End If

    End Function

End Module
