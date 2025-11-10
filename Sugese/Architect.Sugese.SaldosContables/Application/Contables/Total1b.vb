Imports Architect.Utilities.Extensions
Imports ClosedXML.Excel

Friend Class Total1b

    Friend Shared Sub Mapper(_SaldosContables As ModeloSaldosContables)


        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103500000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103500000.cta_10300103501000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103500000.cta_10300103501000
                .Total10300103501000 = 0
                If .cta_10300103501010.IsNotEmpty Then
                    .Total10300103501000 += .cta_10300103501010
                End If
                If .cta_10300103501020.IsNotEmpty Then
                    .Total10300103501000 += .cta_10300103501020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103500000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103500000.cta_10300103502000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103500000.cta_10300103502000
                .Total10300103502000 = 0
                If .cta_10300103502010.IsNotEmpty Then
                    .Total10300103502000 += .cta_10300103502010
                End If
                If .cta_10300103502020.IsNotEmpty Then
                    .Total10300103502000 += .cta_10300103502020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103500000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103500000.cta_10300103503000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103500000.cta_10300103503000
                .Total10300103503000 = 0
                If .cta_10300103503010.IsNotEmpty Then
                    .Total10300103503000 += .cta_10300103503010
                End If
                If .cta_10300103503020.IsNotEmpty Then
                    .Total10300103503000 += .cta_10300103503020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103500000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103500000
                .Total10300103500000 = 0
                If .cta_10300103501000.IsNotEmpty AndAlso .cta_10300103501000.Total10300103501000.IsNotEmpty Then
                    .Total10300103500000 += .cta_10300103501000.Total10300103501000
                End If
                If .cta_10300103502000.IsNotEmpty AndAlso .cta_10300103502000.Total10300103502000.IsNotEmpty Then
                    .Total10300103500000 += .cta_10300103502000.Total10300103502000
                End If
                If .cta_10300103503000.IsNotEmpty AndAlso .cta_10300103503000.Total10300103503000.IsNotEmpty Then
                    .Total10300103500000 += .cta_10300103503000.Total10300103503000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103600000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103600000.cta_10300103601000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103600000.cta_10300103601000
                .Total10300103601000 = 0
                If .cta_10300103601010.IsNotEmpty Then
                    .Total10300103601000 += .cta_10300103601010
                End If
                If .cta_10300103601020.IsNotEmpty Then
                    .Total10300103601000 += .cta_10300103601020
                End If
                If .cta_10300103601100.IsNotEmpty Then
                    .Total10300103601000 += .cta_10300103601100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103600000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103600000.cta_10300103602000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103600000.cta_10300103602000
                .Total10300103602000 = 0
                If .cta_10300103602010.IsNotEmpty Then
                    .Total10300103602000 += .cta_10300103602010
                End If
                If .cta_10300103602020.IsNotEmpty Then
                    .Total10300103602000 += .cta_10300103602020
                End If
                If .cta_10300103602100.IsNotEmpty Then
                    .Total10300103602000 += .cta_10300103602100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103600000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103600000.cta_10300103603000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103600000.cta_10300103603000
                .Total10300103603000 = 0
                If .cta_10300103603010.IsNotEmpty Then
                    .Total10300103603000 += .cta_10300103603010
                End If
                If .cta_10300103603020.IsNotEmpty Then
                    .Total10300103603000 += .cta_10300103603020
                End If
                If .cta_10300103603100.IsNotEmpty Then
                    .Total10300103603000 += .cta_10300103603100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103600000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103600000
                .Total10300103600000 = 0
                If .cta_10300103601000.IsNotEmpty AndAlso .cta_10300103601000.Total10300103601000.IsNotEmpty Then
                    .Total10300103600000 += .cta_10300103601000.Total10300103601000
                End If
                If .cta_10300103602000.IsNotEmpty AndAlso .cta_10300103602000.Total10300103602000.IsNotEmpty Then
                    .Total10300103600000 += .cta_10300103602000.Total10300103602000
                End If
                If .cta_10300103603000.IsNotEmpty AndAlso .cta_10300103603000.Total10300103603000.IsNotEmpty Then
                    .Total10300103600000 += .cta_10300103603000.Total10300103603000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000
                .Total10300100000000 = 0
                If .cta_10300103100000.IsNotEmpty AndAlso .cta_10300103100000.Total10300103100000.IsNotEmpty Then
                    .Total10300100000000 += .cta_10300103100000.Total10300103100000
                End If
                If .cta_10300103300000.IsNotEmpty AndAlso .cta_10300103300000.Total10300103300000.IsNotEmpty Then
                    .Total10300100000000 += .cta_10300103300000.Total10300103300000
                End If
                If .cta_10300103400000.IsNotEmpty AndAlso .cta_10300103400000.Total10300103400000.IsNotEmpty Then
                    .Total10300100000000 += .cta_10300103400000.Total10300103400000
                End If
                If .cta_10300103500000.IsNotEmpty AndAlso .cta_10300103500000.Total10300103500000.IsNotEmpty Then
                    .Total10300100000000 += .cta_10300103500000.Total10300103500000
                End If
                If .cta_10300103600000.IsNotEmpty AndAlso .cta_10300103600000.Total10300103600000.IsNotEmpty Then
                    .Total10300100000000 += .cta_10300103600000.Total10300103600000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203100000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203100000.cta_10300203101000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203100000.cta_10300203101000
                .Total10300203101000 = 0
                If .cta_10300203101010.IsNotEmpty Then
                    .Total10300203101000 += .cta_10300203101010
                End If
                If .cta_10300203101020.IsNotEmpty Then
                    .Total10300203101000 += .cta_10300203101020
                End If
                If .cta_10300203101030.IsNotEmpty Then
                    .Total10300203101000 += .cta_10300203101030
                End If
                If .cta_10300203101100.IsNotEmpty Then
                    .Total10300203101000 += .cta_10300203101100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203100000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203100000.cta_10300203102000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203100000.cta_10300203102000
                .Total10300203102000 = 0
                If .cta_10300203102010.IsNotEmpty Then
                    .Total10300203102000 += .cta_10300203102010
                End If
                If .cta_10300203102020.IsNotEmpty Then
                    .Total10300203102000 += .cta_10300203102020
                End If
                If .cta_10300203102030.IsNotEmpty Then
                    .Total10300203102000 += .cta_10300203102030
                End If
                If .cta_10300203102100.IsNotEmpty Then
                    .Total10300203102000 += .cta_10300203102100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203100000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203100000.cta_10300203103000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203100000.cta_10300203103000
                .Total10300203103000 = 0
                If .cta_10300203103010.IsNotEmpty Then
                    .Total10300203103000 += .cta_10300203103010
                End If
                If .cta_10300203103020.IsNotEmpty Then
                    .Total10300203103000 += .cta_10300203103020
                End If
                If .cta_10300203103030.IsNotEmpty Then
                    .Total10300203103000 += .cta_10300203103030
                End If
                If .cta_10300203103100.IsNotEmpty Then
                    .Total10300203103000 += .cta_10300203103100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203100000
                .Total10300203100000 = 0
                If .cta_10300203101000.IsNotEmpty AndAlso .cta_10300203101000.Total10300203101000.IsNotEmpty Then
                    .Total10300203100000 += .cta_10300203101000.Total10300203101000
                End If
                If .cta_10300203102000.IsNotEmpty AndAlso .cta_10300203102000.Total10300203102000.IsNotEmpty Then
                    .Total10300203100000 += .cta_10300203102000.Total10300203102000
                End If
                If .cta_10300203103000.IsNotEmpty AndAlso .cta_10300203103000.Total10300203103000.IsNotEmpty Then
                    .Total10300203100000 += .cta_10300203103000.Total10300203103000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203300000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203300000.cta_10300203301000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203300000.cta_10300203301000
                .Total10300203301000 = 0
                If .cta_10300203301010.IsNotEmpty Then
                    .Total10300203301000 += .cta_10300203301010
                End If
                If .cta_10300203301100.IsNotEmpty Then
                    .Total10300203301000 += .cta_10300203301100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203300000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203300000.cta_10300203302000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203300000.cta_10300203302000
                .Total10300203302000 = 0
                If .cta_10300203302010.IsNotEmpty Then
                    .Total10300203302000 += .cta_10300203302010
                End If
                If .cta_10300203302100.IsNotEmpty Then
                    .Total10300203302000 += .cta_10300203302100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203300000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203300000.cta_10300203303000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203300000.cta_10300203303000
                .Total10300203303000 = 0
                If .cta_10300203303010.IsNotEmpty Then
                    .Total10300203303000 += .cta_10300203303010
                End If
                If .cta_10300203303100.IsNotEmpty Then
                    .Total10300203303000 += .cta_10300203303100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203300000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203300000
                .Total10300203300000 = 0
                If .cta_10300203301000.IsNotEmpty AndAlso .cta_10300203301000.Total10300203301000.IsNotEmpty Then
                    .Total10300203300000 += .cta_10300203301000.Total10300203301000
                End If
                If .cta_10300203302000.IsNotEmpty AndAlso .cta_10300203302000.Total10300203302000.IsNotEmpty Then
                    .Total10300203300000 += .cta_10300203302000.Total10300203302000
                End If
                If .cta_10300203303000.IsNotEmpty AndAlso .cta_10300203303000.Total10300203303000.IsNotEmpty Then
                    .Total10300203300000 += .cta_10300203303000.Total10300203303000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203400000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203400000.cta_10300203401000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203400000.cta_10300203401000
                .Total10300203401000 = 0
                If .cta_10300203401010.IsNotEmpty Then
                    .Total10300203401000 += .cta_10300203401010
                End If
                If .cta_10300203401100.IsNotEmpty Then
                    .Total10300203401000 += .cta_10300203401100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203400000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203400000.cta_10300203402000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203400000.cta_10300203402000
                .Total10300203402000 = 0
                If .cta_10300203402010.IsNotEmpty Then
                    .Total10300203402000 += .cta_10300203402010
                End If
                If .cta_10300203402100.IsNotEmpty Then
                    .Total10300203402000 += .cta_10300203402100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203400000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203400000.cta_10300203403000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203400000.cta_10300203403000
                .Total10300203403000 = 0
                If .cta_10300203403010.IsNotEmpty Then
                    .Total10300203403000 += .cta_10300203403010
                End If
                If .cta_10300203403100.IsNotEmpty Then
                    .Total10300203403000 += .cta_10300203403100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203400000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203400000
                .Total10300203400000 = 0
                If .cta_10300203401000.IsNotEmpty AndAlso .cta_10300203401000.Total10300203401000.IsNotEmpty Then
                    .Total10300203400000 += .cta_10300203401000.Total10300203401000
                End If
                If .cta_10300203402000.IsNotEmpty AndAlso .cta_10300203402000.Total10300203402000.IsNotEmpty Then
                    .Total10300203400000 += .cta_10300203402000.Total10300203402000
                End If
                If .cta_10300203403000.IsNotEmpty AndAlso .cta_10300203403000.Total10300203403000.IsNotEmpty Then
                    .Total10300203400000 += .cta_10300203403000.Total10300203403000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203500000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203500000.cta_10300203501000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203500000.cta_10300203501000
                .Total10300203501000 = 0
                If .cta_10300203501010.IsNotEmpty Then
                    .Total10300203501000 += .cta_10300203501010
                End If
                If .cta_10300203501020.IsNotEmpty Then
                    .Total10300203501000 += .cta_10300203501020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203500000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203500000.cta_10300203502000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203500000.cta_10300203502000
                .Total10300203502000 = 0
                If .cta_10300203502010.IsNotEmpty Then
                    .Total10300203502000 += .cta_10300203502010
                End If
                If .cta_10300203502020.IsNotEmpty Then
                    .Total10300203502000 += .cta_10300203502020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203500000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203500000.cta_10300203503000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203500000.cta_10300203503000
                .Total10300203503000 = 0
                If .cta_10300203503010.IsNotEmpty Then
                    .Total10300203503000 += .cta_10300203503010
                End If
                If .cta_10300203503020.IsNotEmpty Then
                    .Total10300203503000 += .cta_10300203503020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203500000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203500000
                .Total10300203500000 = 0
                If .cta_10300203501000.IsNotEmpty AndAlso .cta_10300203501000.Total10300203501000.IsNotEmpty Then
                    .Total10300203500000 += .cta_10300203501000.Total10300203501000
                End If
                If .cta_10300203502000.IsNotEmpty AndAlso .cta_10300203502000.Total10300203502000.IsNotEmpty Then
                    .Total10300203500000 += .cta_10300203502000.Total10300203502000
                End If
                If .cta_10300203503000.IsNotEmpty AndAlso .cta_10300203503000.Total10300203503000.IsNotEmpty Then
                    .Total10300203500000 += .cta_10300203503000.Total10300203503000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203600000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203600000.cta_10300203601000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203600000.cta_10300203601000
                .Total10300203601000 = 0
                If .cta_10300203601010.IsNotEmpty Then
                    .Total10300203601000 += .cta_10300203601010
                End If
                If .cta_10300203601020.IsNotEmpty Then
                    .Total10300203601000 += .cta_10300203601020
                End If
                If .cta_10300203601100.IsNotEmpty Then
                    .Total10300203601000 += .cta_10300203601100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203600000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203600000.cta_10300203602000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203600000.cta_10300203602000
                .Total10300203602000 = 0
                If .cta_10300203602010.IsNotEmpty Then
                    .Total10300203602000 += .cta_10300203602010
                End If
                If .cta_10300203602020.IsNotEmpty Then
                    .Total10300203602000 += .cta_10300203602020
                End If
                If .cta_10300203602100.IsNotEmpty Then
                    .Total10300203602000 += .cta_10300203602100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203600000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203600000.cta_10300203603000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203600000.cta_10300203603000
                .Total10300203603000 = 0
                If .cta_10300203603010.IsNotEmpty Then
                    .Total10300203603000 += .cta_10300203603010
                End If
                If .cta_10300203603020.IsNotEmpty Then
                    .Total10300203603000 += .cta_10300203603020
                End If
                If .cta_10300203603100.IsNotEmpty Then
                    .Total10300203603000 += .cta_10300203603100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203600000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203600000
                .Total10300203600000 = 0
                If .cta_10300203601000.IsNotEmpty AndAlso .cta_10300203601000.Total10300203601000.IsNotEmpty Then
                    .Total10300203600000 += .cta_10300203601000.Total10300203601000
                End If
                If .cta_10300203602000.IsNotEmpty AndAlso .cta_10300203602000.Total10300203602000.IsNotEmpty Then
                    .Total10300203600000 += .cta_10300203602000.Total10300203602000
                End If
                If .cta_10300203603000.IsNotEmpty AndAlso .cta_10300203603000.Total10300203603000.IsNotEmpty Then
                    .Total10300203600000 += .cta_10300203603000.Total10300203603000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000
                .Total10300200000000 = 0
                If .cta_10300203100000.IsNotEmpty AndAlso .cta_10300203100000.Total10300203100000.IsNotEmpty Then
                    .Total10300200000000 += .cta_10300203100000.Total10300203100000
                End If
                If .cta_10300203300000.IsNotEmpty AndAlso .cta_10300203300000.Total10300203300000.IsNotEmpty Then
                    .Total10300200000000 += .cta_10300203300000.Total10300203300000
                End If
                If .cta_10300203400000.IsNotEmpty AndAlso .cta_10300203400000.Total10300203400000.IsNotEmpty Then
                    .Total10300200000000 += .cta_10300203400000.Total10300203400000
                End If
                If .cta_10300203500000.IsNotEmpty AndAlso .cta_10300203500000.Total10300203500000.IsNotEmpty Then
                    .Total10300200000000 += .cta_10300203500000.Total10300203500000
                End If
                If .cta_10300203600000.IsNotEmpty AndAlso .cta_10300203600000.Total10300203600000.IsNotEmpty Then
                    .Total10300200000000 += .cta_10300203600000.Total10300203600000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303100000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303100000.cta_10300303101000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303100000.cta_10300303101000
                .Total10300303101000 = 0
                If .cta_10300303101010.IsNotEmpty Then
                    .Total10300303101000 += .cta_10300303101010
                End If
                If .cta_10300303101020.IsNotEmpty Then
                    .Total10300303101000 += .cta_10300303101020
                End If
                If .cta_10300303101030.IsNotEmpty Then
                    .Total10300303101000 += .cta_10300303101030
                End If
                If .cta_10300303101100.IsNotEmpty Then
                    .Total10300303101000 += .cta_10300303101100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303100000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303100000.cta_10300303102000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303100000.cta_10300303102000
                .Total10300303102000 = 0
                If .cta_10300303102010.IsNotEmpty Then
                    .Total10300303102000 += .cta_10300303102010
                End If
                If .cta_10300303102020.IsNotEmpty Then
                    .Total10300303102000 += .cta_10300303102020
                End If
                If .cta_10300303102030.IsNotEmpty Then
                    .Total10300303102000 += .cta_10300303102030
                End If
                If .cta_10300303102100.IsNotEmpty Then
                    .Total10300303102000 += .cta_10300303102100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303100000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303100000.cta_10300303103000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303100000.cta_10300303103000
                .Total10300303103000 = 0
                If .cta_10300303103010.IsNotEmpty Then
                    .Total10300303103000 += .cta_10300303103010
                End If
                If .cta_10300303103020.IsNotEmpty Then
                    .Total10300303103000 += .cta_10300303103020
                End If
                If .cta_10300303103030.IsNotEmpty Then
                    .Total10300303103000 += .cta_10300303103030
                End If
                If .cta_10300303103100.IsNotEmpty Then
                    .Total10300303103000 += .cta_10300303103100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303100000
                .Total10300303100000 = 0
                If .cta_10300303101000.IsNotEmpty AndAlso .cta_10300303101000.Total10300303101000.IsNotEmpty Then
                    .Total10300303100000 += .cta_10300303101000.Total10300303101000
                End If
                If .cta_10300303102000.IsNotEmpty AndAlso .cta_10300303102000.Total10300303102000.IsNotEmpty Then
                    .Total10300303100000 += .cta_10300303102000.Total10300303102000
                End If
                If .cta_10300303103000.IsNotEmpty AndAlso .cta_10300303103000.Total10300303103000.IsNotEmpty Then
                    .Total10300303100000 += .cta_10300303103000.Total10300303103000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303300000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303300000.cta_10300303301000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303300000.cta_10300303301000
                .Total10300303301000 = 0
                If .cta_10300303301010.IsNotEmpty Then
                    .Total10300303301000 += .cta_10300303301010
                End If
                If .cta_10300303301100.IsNotEmpty Then
                    .Total10300303301000 += .cta_10300303301100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303300000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303300000.cta_10300303302000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303300000.cta_10300303302000
                .Total10300303302000 = 0
                If .cta_10300303302010.IsNotEmpty Then
                    .Total10300303302000 += .cta_10300303302010
                End If
                If .cta_10300303302100.IsNotEmpty Then
                    .Total10300303302000 += .cta_10300303302100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303300000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303300000.cta_10300303303000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303300000.cta_10300303303000
                .Total10300303303000 = 0
                If .cta_10300303303010.IsNotEmpty Then
                    .Total10300303303000 += .cta_10300303303010
                End If
                If .cta_10300303303100.IsNotEmpty Then
                    .Total10300303303000 += .cta_10300303303100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303300000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303300000
                .Total10300303300000 = 0
                If .cta_10300303301000.IsNotEmpty AndAlso .cta_10300303301000.Total10300303301000.IsNotEmpty Then
                    .Total10300303300000 += .cta_10300303301000.Total10300303301000
                End If
                If .cta_10300303302000.IsNotEmpty AndAlso .cta_10300303302000.Total10300303302000.IsNotEmpty Then
                    .Total10300303300000 += .cta_10300303302000.Total10300303302000
                End If
                If .cta_10300303303000.IsNotEmpty AndAlso .cta_10300303303000.Total10300303303000.IsNotEmpty Then
                    .Total10300303300000 += .cta_10300303303000.Total10300303303000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303400000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303400000.cta_10300303401000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303400000.cta_10300303401000
                .Total10300303401000 = 0
                If .cta_10300303401010.IsNotEmpty Then
                    .Total10300303401000 += .cta_10300303401010
                End If
                If .cta_10300303401100.IsNotEmpty Then
                    .Total10300303401000 += .cta_10300303401100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303400000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303400000.cta_10300303402000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303400000.cta_10300303402000
                .Total10300303402000 = 0
                If .cta_10300303402010.IsNotEmpty Then
                    .Total10300303402000 += .cta_10300303402010
                End If
                If .cta_10300303402100.IsNotEmpty Then
                    .Total10300303402000 += .cta_10300303402100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303400000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303400000.cta_10300303403000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303400000.cta_10300303403000
                .Total10300303403000 = 0
                If .cta_10300303403010.IsNotEmpty Then
                    .Total10300303403000 += .cta_10300303403010
                End If
                If .cta_10300303403100.IsNotEmpty Then
                    .Total10300303403000 += .cta_10300303403100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303400000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303400000
                .Total10300303400000 = 0
                If .cta_10300303401000.IsNotEmpty AndAlso .cta_10300303401000.Total10300303401000.IsNotEmpty Then
                    .Total10300303400000 += .cta_10300303401000.Total10300303401000
                End If
                If .cta_10300303402000.IsNotEmpty AndAlso .cta_10300303402000.Total10300303402000.IsNotEmpty Then
                    .Total10300303400000 += .cta_10300303402000.Total10300303402000
                End If
                If .cta_10300303403000.IsNotEmpty AndAlso .cta_10300303403000.Total10300303403000.IsNotEmpty Then
                    .Total10300303400000 += .cta_10300303403000.Total10300303403000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303500000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303500000.cta_10300303501000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303500000.cta_10300303501000
                .Total10300303501000 = 0
                If .cta_10300303501010.IsNotEmpty Then
                    .Total10300303501000 += .cta_10300303501010
                End If
                If .cta_10300303501020.IsNotEmpty Then
                    .Total10300303501000 += .cta_10300303501020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303500000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303500000.cta_10300303502000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303500000.cta_10300303502000
                .Total10300303502000 = 0
                If .cta_10300303502010.IsNotEmpty Then
                    .Total10300303502000 += .cta_10300303502010
                End If
                If .cta_10300303502020.IsNotEmpty Then
                    .Total10300303502000 += .cta_10300303502020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303500000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303500000.cta_10300303503000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303500000.cta_10300303503000
                .Total10300303503000 = 0
                If .cta_10300303503010.IsNotEmpty Then
                    .Total10300303503000 += .cta_10300303503010
                End If
                If .cta_10300303503020.IsNotEmpty Then
                    .Total10300303503000 += .cta_10300303503020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303500000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303500000
                .Total10300303500000 = 0
                If .cta_10300303501000.IsNotEmpty AndAlso .cta_10300303501000.Total10300303501000.IsNotEmpty Then
                    .Total10300303500000 += .cta_10300303501000.Total10300303501000
                End If
                If .cta_10300303502000.IsNotEmpty AndAlso .cta_10300303502000.Total10300303502000.IsNotEmpty Then
                    .Total10300303500000 += .cta_10300303502000.Total10300303502000
                End If
                If .cta_10300303503000.IsNotEmpty AndAlso .cta_10300303503000.Total10300303503000.IsNotEmpty Then
                    .Total10300303500000 += .cta_10300303503000.Total10300303503000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303600000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303600000.cta_10300303601000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303600000.cta_10300303601000
                .Total10300303601000 = 0
                If .cta_10300303601010.IsNotEmpty Then
                    .Total10300303601000 += .cta_10300303601010
                End If
                If .cta_10300303601020.IsNotEmpty Then
                    .Total10300303601000 += .cta_10300303601020
                End If
                If .cta_10300303601100.IsNotEmpty Then
                    .Total10300303601000 += .cta_10300303601100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303600000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303600000.cta_10300303602000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303600000.cta_10300303602000
                .Total10300303602000 = 0
                If .cta_10300303602010.IsNotEmpty Then
                    .Total10300303602000 += .cta_10300303602010
                End If
                If .cta_10300303602020.IsNotEmpty Then
                    .Total10300303602000 += .cta_10300303602020
                End If
                If .cta_10300303602100.IsNotEmpty Then
                    .Total10300303602000 += .cta_10300303602100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303600000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303600000.cta_10300303603000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303600000.cta_10300303603000
                .Total10300303603000 = 0
                If .cta_10300303603010.IsNotEmpty Then
                    .Total10300303603000 += .cta_10300303603010
                End If
                If .cta_10300303603020.IsNotEmpty Then
                    .Total10300303603000 += .cta_10300303603020
                End If
                If .cta_10300303603100.IsNotEmpty Then
                    .Total10300303603000 += .cta_10300303603100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303600000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303600000
                .Total10300303600000 = 0
                If .cta_10300303601000.IsNotEmpty AndAlso .cta_10300303601000.Total10300303601000.IsNotEmpty Then
                    .Total10300303600000 += .cta_10300303601000.Total10300303601000
                End If
                If .cta_10300303602000.IsNotEmpty AndAlso .cta_10300303602000.Total10300303602000.IsNotEmpty Then
                    .Total10300303600000 += .cta_10300303602000.Total10300303602000
                End If
                If .cta_10300303603000.IsNotEmpty AndAlso .cta_10300303603000.Total10300303603000.IsNotEmpty Then
                    .Total10300303600000 += .cta_10300303603000.Total10300303603000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000
                .Total10300300000000 = 0
                If .cta_10300303100000.IsNotEmpty AndAlso .cta_10300303100000.Total10300303100000.IsNotEmpty Then
                    .Total10300300000000 += .cta_10300303100000.Total10300303100000
                End If
                If .cta_10300303300000.IsNotEmpty AndAlso .cta_10300303300000.Total10300303300000.IsNotEmpty Then
                    .Total10300300000000 += .cta_10300303300000.Total10300303300000
                End If
                If .cta_10300303400000.IsNotEmpty AndAlso .cta_10300303400000.Total10300303400000.IsNotEmpty Then
                    .Total10300300000000 += .cta_10300303400000.Total10300303400000
                End If
                If .cta_10300303500000.IsNotEmpty AndAlso .cta_10300303500000.Total10300303500000.IsNotEmpty Then
                    .Total10300300000000 += .cta_10300303500000.Total10300303500000
                End If
                If .cta_10300303600000.IsNotEmpty AndAlso .cta_10300303600000.Total10300303600000.IsNotEmpty Then
                    .Total10300300000000 += .cta_10300303600000.Total10300303600000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300400000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300400000000.cta_10300400100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300400000000.cta_10300400100000
                .Total10300400100000 = 0
                If .cta_10300400101000.IsNotEmpty Then
                    .Total10300400100000 += .cta_10300400101000
                End If
                If .cta_10300400102000.IsNotEmpty Then
                    .Total10300400100000 += .cta_10300400102000
                End If
                If .cta_10300400103000.IsNotEmpty Then
                    .Total10300400100000 += .cta_10300400103000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300400000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300400000000.cta_10300400200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300400000000.cta_10300400200000
                .Total10300400200000 = 0
                If .cta_10300400201000.IsNotEmpty Then
                    .Total10300400200000 += .cta_10300400201000
                End If
                If .cta_10300400202000.IsNotEmpty Then
                    .Total10300400200000 += .cta_10300400202000
                End If
                If .cta_10300400203000.IsNotEmpty Then
                    .Total10300400200000 += .cta_10300400203000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300400000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300400000000.cta_10300400300000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300400000000.cta_10300400300000
                .Total10300400300000 = 0
                If .cta_10300400301000.IsNotEmpty Then
                    .Total10300400300000 += .cta_10300400301000
                End If
                If .cta_10300400302000.IsNotEmpty Then
                    .Total10300400300000 += .cta_10300400302000
                End If
                If .cta_10300400303000.IsNotEmpty Then
                    .Total10300400300000 += .cta_10300400303000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300400000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300400000000
                .Total10300400000000 = 0
                If .cta_10300400100000.IsNotEmpty AndAlso .cta_10300400100000.Total10300400100000.IsNotEmpty Then
                    .Total10300400000000 += .cta_10300400100000.Total10300400100000
                End If
                If .cta_10300400200000.IsNotEmpty AndAlso .cta_10300400200000.Total10300400200000.IsNotEmpty Then
                    .Total10300400000000 += .cta_10300400200000.Total10300400200000
                End If
                If .cta_10300400300000.IsNotEmpty AndAlso .cta_10300400300000.Total10300400300000.IsNotEmpty Then
                    .Total10300400000000 += .cta_10300400300000.Total10300400300000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300600000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300600000000.cta_10300600100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300600000000.cta_10300600100000
                .Total10300600100000 = 0
                If .cta_10300600101000.IsNotEmpty Then
                    .Total10300600100000 += .cta_10300600101000
                End If
                If .cta_10300600102000.IsNotEmpty Then
                    .Total10300600100000 += .cta_10300600102000
                End If
                If .cta_10300600103000.IsNotEmpty Then
                    .Total10300600100000 += .cta_10300600103000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300600000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300600000000.cta_10300600200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300600000000.cta_10300600200000
                .Total10300600200000 = 0
                If .cta_10300600201000.IsNotEmpty Then
                    .Total10300600200000 += .cta_10300600201000
                End If
                If .cta_10300600202000.IsNotEmpty Then
                    .Total10300600200000 += .cta_10300600202000
                End If
                If .cta_10300600203000.IsNotEmpty Then
                    .Total10300600200000 += .cta_10300600203000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300600000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300600000000
                .Total10300600000000 = 0
                If .cta_10300600100000.IsNotEmpty AndAlso .cta_10300600100000.Total10300600100000.IsNotEmpty Then
                    .Total10300600000000 += .cta_10300600100000.Total10300600100000
                End If
                If .cta_10300600200000.IsNotEmpty AndAlso .cta_10300600200000.Total10300600200000.IsNotEmpty Then
                    .Total10300600000000 += .cta_10300600200000.Total10300600200000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300700000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300700000000.cta_10300700200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300700000000.cta_10300700200000
                .Total10300700200000 = 0
                If .cta_10300700201000.IsNotEmpty Then
                    .Total10300700200000 += .cta_10300700201000
                End If
                If .cta_10300700202000.IsNotEmpty Then
                    .Total10300700200000 += .cta_10300700202000
                End If
                If .cta_10300700203000.IsNotEmpty Then
                    .Total10300700200000 += .cta_10300700203000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300700000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300700000000.cta_10300700300000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300700000000.cta_10300700300000
                .Total10300700300000 = 0
                If .cta_10300700301000.IsNotEmpty Then
                    .Total10300700300000 += .cta_10300700301000
                End If
                If .cta_10300700302000.IsNotEmpty Then
                    .Total10300700300000 += .cta_10300700302000
                End If
                If .cta_10300700303000.IsNotEmpty Then
                    .Total10300700300000 += .cta_10300700303000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300700000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300700000000.cta_10300700400000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300700000000.cta_10300700400000
                .Total10300700400000 = 0
                If .cta_10300700401000.IsNotEmpty Then
                    .Total10300700400000 += .cta_10300700401000
                End If
                If .cta_10300700402000.IsNotEmpty Then
                    .Total10300700400000 += .cta_10300700402000
                End If
                If .cta_10300700403000.IsNotEmpty Then
                    .Total10300700400000 += .cta_10300700403000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300700000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300700000000
                .Total10300700000000 = 0
                If .cta_10300700200000.IsNotEmpty AndAlso .cta_10300700200000.Total10300700200000.IsNotEmpty Then
                    .Total10300700000000 += .cta_10300700200000.Total10300700200000
                End If
                If .cta_10300700300000.IsNotEmpty AndAlso .cta_10300700300000.Total10300700300000.IsNotEmpty Then
                    .Total10300700000000 += .cta_10300700300000.Total10300700300000
                End If
                If .cta_10300700400000.IsNotEmpty AndAlso .cta_10300700400000.Total10300700400000.IsNotEmpty Then
                    .Total10300700000000 += .cta_10300700400000.Total10300700400000
                End If
            End With
        End If
        'If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300800300000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300800300000.cta_10300800301000.IsNotEmpty Then
        '    With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300800300000.cta_10300800301000
        '        .Total10300800301000 = 0
        '        If .cta_10300800301010.IsNotEmpty Then
        '            .Total10300800301000 += .cta_10300800301010
        '        End If
        '        If .cta_10300800301020.IsNotEmpty Then
        '            .Total10300800301000 += .cta_10300800301020
        '        End If
        '        If .cta_10300800301030.IsNotEmpty Then
        '            .Total10300800301000 += .cta_10300800301030
        '        End If
        '    End With
        'End If
        'If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300800300000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300800300000.cta_10300800302000.IsNotEmpty Then
        '    With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300800300000.cta_10300800302000
        '        .Total10300800302000 = 0
        '        If .cta_10300800302010.IsNotEmpty Then
        '            .Total10300800302000 += .cta_10300800302010
        '        End If
        '        If .cta_10300800302020.IsNotEmpty Then
        '            .Total10300800302000 += .cta_10300800302020
        '        End If
        '        If .cta_10300800302030.IsNotEmpty Then
        '            .Total10300800302000 += .cta_10300800302030
        '        End If
        '    End With
        'End If
        'If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300800300000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300800300000.cta_10300800303000.IsNotEmpty Then
        '    With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300800300000.cta_10300800303000
        '        .Total10300800303000 = 0
        '        If .cta_10300800303010.IsNotEmpty Then
        '            .Total10300800303000 += .cta_10300800303010
        '        End If
        '        If .cta_10300800303020.IsNotEmpty Then
        '            .Total10300800303000 += .cta_10300800303020
        '        End If
        '        If .cta_10300800303030.IsNotEmpty Then
        '            .Total10300800303000 += .cta_10300800303030
        '        End If
        '    End With
        'End If
        'If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300800300000.IsNotEmpty Then
        '    With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300800300000
        '        .Total10300800300000 = 0
        '        If .cta_10300800301000.IsNotEmpty AndAlso .cta_10300800301000.Total10300800301000.IsNotEmpty Then
        '            .Total10300800300000 += .cta_10300800301000.Total10300800301000
        '        End If
        '        If .cta_10300800302000.IsNotEmpty AndAlso .cta_10300800302000.Total10300800302000.IsNotEmpty Then
        '            .Total10300800300000 += .cta_10300800302000.Total10300800302000
        '        End If
        '        If .cta_10300800303000.IsNotEmpty AndAlso .cta_10300800303000.Total10300800303000.IsNotEmpty Then
        '            .Total10300800300000 += .cta_10300800303000.Total10300800303000
        '        End If
        '    End With
        'End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803100000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803100000.cta_10300803101000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803100000.cta_10300803101000
                .Total10300803101000 = 0
                If .cta_10300803101010.IsNotEmpty Then
                    .Total10300803101000 += .cta_10300803101010
                End If
                If .cta_10300803101020.IsNotEmpty Then
                    .Total10300803101000 += .cta_10300803101020
                End If
                If .cta_10300803101030.IsNotEmpty Then
                    .Total10300803101000 += .cta_10300803101030
                End If
                If .cta_10300803101100.IsNotEmpty Then
                    .Total10300803101000 += .cta_10300803101100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803100000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803100000.cta_10300803102000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803100000.cta_10300803102000
                .Total10300803102000 = 0
                If .cta_10300803102010.IsNotEmpty Then
                    .Total10300803102000 += .cta_10300803102010
                End If
                If .cta_10300803102020.IsNotEmpty Then
                    .Total10300803102000 += .cta_10300803102020
                End If
                If .cta_10300803102030.IsNotEmpty Then
                    .Total10300803102000 += .cta_10300803102030
                End If
                If .cta_10300803102100.IsNotEmpty Then
                    .Total10300803102000 += .cta_10300803102100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803100000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803100000.cta_10300803103000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803100000.cta_10300803103000
                .Total10300803103000 = 0
                If .cta_10300803103010.IsNotEmpty Then
                    .Total10300803103000 += .cta_10300803103010
                End If
                If .cta_10300803103020.IsNotEmpty Then
                    .Total10300803103000 += .cta_10300803103020
                End If
                If .cta_10300803103030.IsNotEmpty Then
                    .Total10300803103000 += .cta_10300803103030
                End If
                If .cta_10300803103100.IsNotEmpty Then
                    .Total10300803103000 += .cta_10300803103100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803100000
                .Total10300803100000 = 0
                If .cta_10300803101000.IsNotEmpty AndAlso .cta_10300803101000.Total10300803101000.IsNotEmpty Then
                    .Total10300803100000 += .cta_10300803101000.Total10300803101000
                End If
                If .cta_10300803102000.IsNotEmpty AndAlso .cta_10300803102000.Total10300803102000.IsNotEmpty Then
                    .Total10300803100000 += .cta_10300803102000.Total10300803102000
                End If
                If .cta_10300803103000.IsNotEmpty AndAlso .cta_10300803103000.Total10300803103000.IsNotEmpty Then
                    .Total10300803100000 += .cta_10300803103000.Total10300803103000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803300000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803300000.cta_10300803301000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803300000.cta_10300803301000
                .Total10300803301000 = 0
                If .cta_10300803301010.IsNotEmpty Then
                    .Total10300803301000 += .cta_10300803301010
                End If
                If .cta_10300803301020.IsNotEmpty Then
                    .Total10300803301000 += .cta_10300803301020
                End If
                If .cta_10300803301030.IsNotEmpty Then
                    .Total10300803301000 += .cta_10300803301030
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803300000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803300000.cta_10300803302000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803300000.cta_10300803302000
                .Total10300803302000 = 0
                If .cta_10300803302010.IsNotEmpty Then
                    .Total10300803302000 += .cta_10300803302010
                End If
                If .cta_10300803302020.IsNotEmpty Then
                    .Total10300803302000 += .cta_10300803302020
                End If
                If .cta_10300803302030.IsNotEmpty Then
                    .Total10300803302000 += .cta_10300803302030
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803300000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803300000.cta_10300803303000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803300000.cta_10300803303000
                .Total10300803303000 = 0
                If .cta_10300803303010.IsNotEmpty Then
                    .Total10300803303000 += .cta_10300803303010
                End If
                If .cta_10300803303020.IsNotEmpty Then
                    .Total10300803303000 += .cta_10300803303020
                End If
                If .cta_10300803303030.IsNotEmpty Then
                    .Total10300803303000 += .cta_10300803303030
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803300000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803300000
                .Total10300803300000 = 0
                If .cta_10300803301000.IsNotEmpty AndAlso .cta_10300803301000.Total10300803301000.IsNotEmpty Then
                    .Total10300803300000 += .cta_10300803301000.Total10300803301000
                End If
                If .cta_10300803302000.IsNotEmpty AndAlso .cta_10300803302000.Total10300803302000.IsNotEmpty Then
                    .Total10300803300000 += .cta_10300803302000.Total10300803302000
                End If
                If .cta_10300803303000.IsNotEmpty AndAlso .cta_10300803303000.Total10300803303000.IsNotEmpty Then
                    .Total10300803300000 += .cta_10300803303000.Total10300803303000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803400000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803400000.cta_10300803401000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803400000.cta_10300803401000
                .Total10300803401000 = 0
                If .cta_10300803401010.IsNotEmpty Then
                    .Total10300803401000 += .cta_10300803401010
                End If
                If .cta_10300803401100.IsNotEmpty Then
                    .Total10300803401000 += .cta_10300803401100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803400000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803400000.cta_10300803402000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803400000.cta_10300803402000
                .Total10300803402000 = 0
                If .cta_10300803402010.IsNotEmpty Then
                    .Total10300803402000 += .cta_10300803402010
                End If
                If .cta_10300803402100.IsNotEmpty Then
                    .Total10300803402000 += .cta_10300803402100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803400000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803400000.cta_10300803403000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803400000.cta_10300803403000
                .Total10300803403000 = 0
                If .cta_10300803403010.IsNotEmpty Then
                    .Total10300803403000 += .cta_10300803403010
                End If
                If .cta_10300803403100.IsNotEmpty Then
                    .Total10300803403000 += .cta_10300803403100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803400000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803400000
                .Total10300803400000 = 0
                If .cta_10300803401000.IsNotEmpty AndAlso .cta_10300803401000.Total10300803401000.IsNotEmpty Then
                    .Total10300803400000 += .cta_10300803401000.Total10300803401000
                End If
                If .cta_10300803402000.IsNotEmpty AndAlso .cta_10300803402000.Total10300803402000.IsNotEmpty Then
                    .Total10300803400000 += .cta_10300803402000.Total10300803402000
                End If
                If .cta_10300803403000.IsNotEmpty AndAlso .cta_10300803403000.Total10300803403000.IsNotEmpty Then
                    .Total10300803400000 += .cta_10300803403000.Total10300803403000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803500000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803500000.cta_10300803501000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803500000.cta_10300803501000
                .Total10300803501000 = 0
                If .cta_10300803501010.IsNotEmpty Then
                    .Total10300803501000 += .cta_10300803501010
                End If
                If .cta_10300803501100.IsNotEmpty Then
                    .Total10300803501000 += .cta_10300803501100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803500000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803500000.cta_10300803502000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803500000.cta_10300803502000
                .Total10300803502000 = 0
                If .cta_10300803502010.IsNotEmpty Then
                    .Total10300803502000 += .cta_10300803502010
                End If
                If .cta_10300803502100.IsNotEmpty Then
                    .Total10300803502000 += .cta_10300803502100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803500000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803500000.cta_10300803503000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803500000.cta_10300803503000
                .Total10300803503000 = 0
                If .cta_10300803503010.IsNotEmpty Then
                    .Total10300803503000 += .cta_10300803503010
                End If
                If .cta_10300803503100.IsNotEmpty Then
                    .Total10300803503000 += .cta_10300803503100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803500000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803500000
                .Total10300803500000 = 0
                If .cta_10300803501000.IsNotEmpty AndAlso .cta_10300803501000.Total10300803501000.IsNotEmpty Then
                    .Total10300803500000 += .cta_10300803501000.Total10300803501000
                End If
                If .cta_10300803502000.IsNotEmpty AndAlso .cta_10300803502000.Total10300803502000.IsNotEmpty Then
                    .Total10300803500000 += .cta_10300803502000.Total10300803502000
                End If
                If .cta_10300803503000.IsNotEmpty AndAlso .cta_10300803503000.Total10300803503000.IsNotEmpty Then
                    .Total10300803500000 += .cta_10300803503000.Total10300803503000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803600000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803600000.cta_10300803601000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803600000.cta_10300803601000
                .Total10300803601000 = 0
                If .cta_10300803601010.IsNotEmpty Then
                    .Total10300803601000 += .cta_10300803601010
                End If
                If .cta_10300803601020.IsNotEmpty Then
                    .Total10300803601000 += .cta_10300803601020
                End If
                'If .cta_10300803601100.IsNotEmpty Then
                '    .Total10300803601000 += .cta_10300803601100
                'End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803600000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803600000.cta_10300803602000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803600000.cta_10300803602000
                .Total10300803602000 = 0
                If .cta_10300803602010.IsNotEmpty Then
                    .Total10300803602000 += .cta_10300803602010
                End If
                If .cta_10300803602020.IsNotEmpty Then
                    .Total10300803602000 += .cta_10300803602020
                End If
                'If .cta_10300803602100.IsNotEmpty Then
                '    .Total10300803602000 += .cta_10300803602100
                'End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803600000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803600000.cta_10300803603000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803600000.cta_10300803603000
                .Total10300803603000 = 0
                If .cta_10300803603010.IsNotEmpty Then
                    .Total10300803603000 += .cta_10300803603010
                End If
                If .cta_10300803603020.IsNotEmpty Then
                    .Total10300803603000 += .cta_10300803603020
                End If
                'If .cta_10300803603100.IsNotEmpty Then
                '    .Total10300803603000 += .cta_10300803603100
                'End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803600000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803600000
                .Total10300803600000 = 0
                If .cta_10300803601000.IsNotEmpty AndAlso .cta_10300803601000.Total10300803601000.IsNotEmpty Then
                    .Total10300803600000 += .cta_10300803601000.Total10300803601000
                End If
                If .cta_10300803602000.IsNotEmpty AndAlso .cta_10300803602000.Total10300803602000.IsNotEmpty Then
                    .Total10300803600000 += .cta_10300803602000.Total10300803602000
                End If
                If .cta_10300803603000.IsNotEmpty AndAlso .cta_10300803603000.Total10300803603000.IsNotEmpty Then
                    .Total10300803600000 += .cta_10300803603000.Total10300803603000
                End If
            End With
        End If

        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803700000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803700000.cta_10300803701000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803700000.cta_10300803701000
                .Total10300803701000 = 0
                If .cta_10300803701010.IsNotEmpty Then
                    .Total10300803701000 += .cta_10300803701010
                End If
                If .cta_10300803701020.IsNotEmpty Then
                    .Total10300803701000 += .cta_10300803701020
                End If
                If .cta_10300803701100.IsNotEmpty Then
                    .Total10300803701000 += .cta_10300803701100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803700000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803700000.cta_10300803702000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803700000.cta_10300803702000
                .Total10300803702000 = 0
                If .cta_10300803702010.IsNotEmpty Then
                    .Total10300803702000 += .cta_10300803702010
                End If
                If .cta_10300803702020.IsNotEmpty Then
                    .Total10300803702000 += .cta_10300803702020
                End If
                If .cta_10300803702100.IsNotEmpty Then
                    .Total10300803702000 += .cta_10300803702100
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803700000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803700000.cta_10300803703000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803700000.cta_10300803703000
                .Total10300803703000 = 0
                If .cta_10300803703010.IsNotEmpty Then
                    .Total10300803703000 += .cta_10300803703010
                End If
                If .cta_10300803703020.IsNotEmpty Then
                    .Total10300803703000 += .cta_10300803703020
                End If
                If .cta_10300803703100.IsNotEmpty Then
                    .Total10300803703000 += .cta_10300803703100
                End If
            End With
        End If

        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803700000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803700000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803700000
                .Total10300803700000 = 0
                If .cta_10300803701000.IsNotEmpty AndAlso .cta_10300803701000.Total10300803701000.IsNotEmpty Then
                    .Total10300803700000 += .cta_10300803701000.Total10300803701000
                End If
                If .cta_10300803702000.IsNotEmpty AndAlso .cta_10300803702000.Total10300803702000.IsNotEmpty Then
                    .Total10300803700000 += .cta_10300803702000.Total10300803702000
                End If
                If .cta_10300803703000.IsNotEmpty AndAlso .cta_10300803703000.Total10300803703000.IsNotEmpty Then
                    .Total10300803700000 += .cta_10300803703000.Total10300803703000
                End If
            End With
        End If

        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300804100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300804100000
                .Total10300804100000 = 0
                If .cta_10300804101000.IsNotEmpty Then
                    .Total10300804100000 += .cta_10300804101000
                End If
                If .cta_10300804102000.IsNotEmpty Then
                    .Total10300804100000 += .cta_10300804102000
                End If
                If .cta_10300804103000.IsNotEmpty Then
                    .Total10300804100000 += .cta_10300804103000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000
                .Total10300800000000 = 0
                'If .cta_10300800300000.IsNotEmpty AndAlso .cta_10300800300000.Total10300800300000.IsNotEmpty Then
                '    .Total10300800000000 += .cta_10300800300000.Total10300800300000
                'End If
                If .cta_10300803100000.IsNotEmpty AndAlso .cta_10300803100000.Total10300803100000.IsNotEmpty Then
                    .Total10300800000000 += .cta_10300803100000.Total10300803100000
                End If
                If .cta_10300803300000.IsNotEmpty AndAlso .cta_10300803300000.Total10300803300000.IsNotEmpty Then
                    .Total10300800000000 += .cta_10300803300000.Total10300803300000
                End If
                If .cta_10300803400000.IsNotEmpty AndAlso .cta_10300803400000.Total10300803400000.IsNotEmpty Then
                    .Total10300800000000 += .cta_10300803400000.Total10300803400000
                End If
                If .cta_10300803500000.IsNotEmpty AndAlso .cta_10300803500000.Total10300803500000.IsNotEmpty Then
                    .Total10300800000000 += .cta_10300803500000.Total10300803500000
                End If
                If .cta_10300803600000.IsNotEmpty AndAlso .cta_10300803600000.Total10300803600000.IsNotEmpty Then
                    .Total10300800000000 += .cta_10300803600000.Total10300803600000
                End If
                If .cta_10300803700000.IsNotEmpty AndAlso .cta_10300803700000.Total10300803700000.IsNotEmpty Then
                    .Total10300800000000 += .cta_10300803700000.Total10300803700000
                End If
                If .cta_10300804100000.IsNotEmpty AndAlso .cta_10300804100000.Total10300804100000.IsNotEmpty Then
                    .Total10300800000000 += .cta_10300804100000.Total10300804100000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300900100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300900100000
                .Total10300900100000 = 0
                If .cta_10300900101000.IsNotEmpty Then
                    .Total10300900100000 += .cta_10300900101000
                End If
                If .cta_10300900102000.IsNotEmpty Then
                    .Total10300900100000 += .cta_10300900102000
                End If
                If .cta_10300900103000.IsNotEmpty Then
                    .Total10300900100000 += .cta_10300900103000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300900200000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300900200000.cta_10300900201000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300900200000.cta_10300900201000
                .Total10300900201000 = 0
                If .cta_10300900201010.IsNotEmpty Then
                    .Total10300900201000 += .cta_10300900201010
                End If
                If .cta_10300900201020.IsNotEmpty Then
                    .Total10300900201000 += .cta_10300900201020
                End If
                If .cta_10300900201040.IsNotEmpty Then
                    .Total10300900201000 += .cta_10300900201040
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300900200000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300900200000.cta_10300900202000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300900200000.cta_10300900202000
                .Total10300900202000 = 0
                If .cta_10300900202010.IsNotEmpty Then
                    .Total10300900202000 += .cta_10300900202010
                End If
                If .cta_10300900202020.IsNotEmpty Then
                    .Total10300900202000 += .cta_10300900202020
                End If
                If .cta_10300900202040.IsNotEmpty Then
                    .Total10300900202000 += .cta_10300900202040
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300900200000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300900200000.cta_10300900203000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300900200000.cta_10300900203000
                .Total10300900203000 = 0
                If .cta_10300900203010.IsNotEmpty Then
                    .Total10300900203000 += .cta_10300900203010
                End If
                If .cta_10300900203020.IsNotEmpty Then
                    .Total10300900203000 += .cta_10300900203020
                End If
                If .cta_10300900203040.IsNotEmpty Then
                    .Total10300900203000 += .cta_10300900203040
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300900200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300900200000
                .Total10300900200000 = 0
                If .cta_10300900201000.IsNotEmpty AndAlso .cta_10300900201000.Total10300900201000.IsNotEmpty Then
                    .Total10300900200000 += .cta_10300900201000.Total10300900201000
                End If
                If .cta_10300900202000.IsNotEmpty AndAlso .cta_10300900202000.Total10300900202000.IsNotEmpty Then
                    .Total10300900200000 += .cta_10300900202000.Total10300900202000
                End If
                If .cta_10300900203000.IsNotEmpty AndAlso .cta_10300900203000.Total10300900203000.IsNotEmpty Then
                    .Total10300900200000 += .cta_10300900203000.Total10300900203000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300901000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300901000000
                .Total10300901000000 = 0
                If .cta_10300901001000.IsNotEmpty Then
                    .Total10300901000000 += .cta_10300901001000
                End If
                If .cta_10300901002000.IsNotEmpty Then
                    .Total10300901000000 += .cta_10300901002000
                End If
                If .cta_10300901003000.IsNotEmpty Then
                    .Total10300901000000 += .cta_10300901003000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300905200000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300905200000.cta_10300905201000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300905200000.cta_10300905201000
                .Total10300905201000 = 0
                If .cta_10300905201010.IsNotEmpty Then
                    .Total10300905201000 += .cta_10300905201010
                End If
                If .cta_10300905201020.IsNotEmpty Then
                    .Total10300905201000 += .cta_10300905201020
                End If
                If .cta_10300905201030.IsNotEmpty Then
                    .Total10300905201000 += .cta_10300905201030
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300905200000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300905200000.cta_10300905202000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300905200000.cta_10300905202000
                .Total10300905202000 = 0
                If .cta_10300905202010.IsNotEmpty Then
                    .Total10300905202000 += .cta_10300905202010
                End If
                If .cta_10300905202020.IsNotEmpty Then
                    .Total10300905202000 += .cta_10300905202020
                End If
                If .cta_10300905202030.IsNotEmpty Then
                    .Total10300905202000 += .cta_10300905202030
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300905200000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300905200000.cta_10300905203000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300905200000.cta_10300905203000
                .Total10300905203000 = 0
                If .cta_10300905203010.IsNotEmpty Then
                    .Total10300905203000 += .cta_10300905203010
                End If
                If .cta_10300905203020.IsNotEmpty Then
                    .Total10300905203000 += .cta_10300905203020
                End If
                If .cta_10300905203030.IsNotEmpty Then
                    .Total10300905203000 += .cta_10300905203030
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300905200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300905200000
                .Total10300905200000 = 0
                If .cta_10300905201000.IsNotEmpty AndAlso .cta_10300905201000.Total10300905201000.IsNotEmpty Then
                    .Total10300905200000 += .cta_10300905201000.Total10300905201000
                End If
                If .cta_10300905202000.IsNotEmpty AndAlso .cta_10300905202000.Total10300905202000.IsNotEmpty Then
                    .Total10300905200000 += .cta_10300905202000.Total10300905202000
                End If
                If .cta_10300905203000.IsNotEmpty AndAlso .cta_10300905203000.Total10300905203000.IsNotEmpty Then
                    .Total10300905200000 += .cta_10300905203000.Total10300905203000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000
                .Total10300900000000 = 0
                If .cta_10300900100000.IsNotEmpty AndAlso .cta_10300900100000.Total10300900100000.IsNotEmpty Then
                    .Total10300900000000 += .cta_10300900100000.Total10300900100000
                End If
                If .cta_10300900200000.IsNotEmpty AndAlso .cta_10300900200000.Total10300900200000.IsNotEmpty Then
                    .Total10300900000000 += .cta_10300900200000.Total10300900200000
                End If
                If .cta_10300901000000.IsNotEmpty AndAlso .cta_10300901000000.Total10300901000000.IsNotEmpty Then
                    .Total10300900000000 += .cta_10300901000000.Total10300901000000
                End If
                If .cta_10300905200000.IsNotEmpty AndAlso .cta_10300905200000.Total10300905200000.IsNotEmpty Then
                    .Total10300900000000 += .cta_10300905200000.Total10300905200000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10300000000000
                .Total10300000000000 = 0
                If .cta_10300100000000.IsNotEmpty AndAlso .cta_10300100000000.Total10300100000000.IsNotEmpty Then
                    .Total10300000000000 += .cta_10300100000000.Total10300100000000
                End If
                If .cta_10300200000000.IsNotEmpty AndAlso .cta_10300200000000.Total10300200000000.IsNotEmpty Then
                    .Total10300000000000 += .cta_10300200000000.Total10300200000000
                End If
                If .cta_10300300000000.IsNotEmpty AndAlso .cta_10300300000000.Total10300300000000.IsNotEmpty Then
                    .Total10300000000000 += .cta_10300300000000.Total10300300000000
                End If
                If .cta_10300400000000.IsNotEmpty AndAlso .cta_10300400000000.Total10300400000000.IsNotEmpty Then
                    .Total10300000000000 += .cta_10300400000000.Total10300400000000
                End If
                If .cta_10300600000000.IsNotEmpty AndAlso .cta_10300600000000.Total10300600000000.IsNotEmpty Then
                    .Total10300000000000 += .cta_10300600000000.Total10300600000000
                End If
                If .cta_10300700000000.IsNotEmpty AndAlso .cta_10300700000000.Total10300700000000.IsNotEmpty Then
                    .Total10300000000000 += .cta_10300700000000.Total10300700000000
                End If
                If .cta_10300800000000.IsNotEmpty AndAlso .cta_10300800000000.Total10300800000000.IsNotEmpty Then
                    .Total10300000000000 += .cta_10300800000000.Total10300800000000
                End If
                If .cta_10300900000000.IsNotEmpty AndAlso .cta_10300900000000.Total10300900000000.IsNotEmpty Then
                    .Total10300000000000 += .cta_10300900000000.Total10300900000000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400200000000.cta_10400201000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400200000000.cta_10400201000000.cta_10400201001000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400200000000.cta_10400201000000.cta_10400201001000
                .Total10400201001000 = 0
                If .cta_10400201001070.IsNotEmpty Then
                    .Total10400201001000 += .cta_10400201001070
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400200000000.cta_10400201000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400200000000.cta_10400201000000.cta_10400201002000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400200000000.cta_10400201000000.cta_10400201002000
                .Total10400201002000 = 0
                If .cta_10400201002070.IsNotEmpty Then
                    .Total10400201002000 += .cta_10400201002070
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400200000000.cta_10400201000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400200000000.cta_10400201000000
                .Total10400201000000 = 0
                If .cta_10400201001000.IsNotEmpty AndAlso .cta_10400201001000.Total10400201001000.IsNotEmpty Then
                    .Total10400201000000 += .cta_10400201001000.Total10400201001000
                End If
                If .cta_10400201002000.IsNotEmpty AndAlso .cta_10400201002000.Total10400201002000.IsNotEmpty Then
                    .Total10400201000000 += .cta_10400201002000.Total10400201002000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400200000000.cta_10400209900000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400200000000.cta_10400209900000
                .Total10400209900000 = 0
                If .cta_10400209901000.IsNotEmpty Then
                    .Total10400209900000 += .cta_10400209901000
                End If
                If .cta_10400209902000.IsNotEmpty Then
                    .Total10400209900000 += .cta_10400209902000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400200000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400200000000
                .Total10400200000000 = 0
                If .cta_10400201000000.IsNotEmpty AndAlso .cta_10400201000000.Total10400201000000.IsNotEmpty Then
                    .Total10400200000000 += .cta_10400201000000.Total10400201000000
                End If
                If .cta_10400209900000.IsNotEmpty AndAlso .cta_10400209900000.Total10400209900000.IsNotEmpty Then
                    .Total10400200000000 += .cta_10400209900000.Total10400209900000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400300000000.cta_10400300100000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400300000000.cta_10400300100000.cta_10400300101000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400300000000.cta_10400300100000.cta_10400300101000
                .Total10400300101000 = 0
                If .cta_10400300101010.IsNotEmpty Then
                    .Total10400300101000 += .cta_10400300101010
                End If
                If .cta_10400300101020.IsNotEmpty Then
                    .Total10400300101000 += .cta_10400300101020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400300000000.cta_10400300100000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400300000000.cta_10400300100000.cta_10400300102000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400300000000.cta_10400300100000.cta_10400300102000
                .Total10400300102000 = 0
                If .cta_10400300102010.IsNotEmpty Then
                    .Total10400300102000 += .cta_10400300102010
                End If
                If .cta_10400300102020.IsNotEmpty Then
                    .Total10400300102000 += .cta_10400300102020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400300000000.cta_10400300100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400300000000.cta_10400300100000
                .Total10400300100000 = 0
                If .cta_10400300101000.IsNotEmpty AndAlso .cta_10400300101000.Total10400300101000.IsNotEmpty Then
                    .Total10400300100000 += .cta_10400300101000.Total10400300101000
                End If
                If .cta_10400300102000.IsNotEmpty AndAlso .cta_10400300102000.Total10400300102000.IsNotEmpty Then
                    .Total10400300100000 += .cta_10400300102000.Total10400300102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400300000000.cta_10400300200000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400300000000.cta_10400300200000.cta_10400300201000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400300000000.cta_10400300200000.cta_10400300201000
                .Total10400300201000 = 0
                If .cta_10400300201010.IsNotEmpty Then
                    .Total10400300201000 += .cta_10400300201010
                End If
                If .cta_10400300201020.IsNotEmpty Then
                    .Total10400300201000 += .cta_10400300201020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400300000000.cta_10400300200000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400300000000.cta_10400300200000.cta_10400300202000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400300000000.cta_10400300200000.cta_10400300202000
                .Total10400300202000 = 0
                If .cta_10400300202010.IsNotEmpty Then
                    .Total10400300202000 += .cta_10400300202010
                End If
                If .cta_10400300202020.IsNotEmpty Then
                    .Total10400300202000 += .cta_10400300202020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400300000000.cta_10400300200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400300000000.cta_10400300200000
                .Total10400300200000 = 0
                If .cta_10400300201000.IsNotEmpty AndAlso .cta_10400300201000.Total10400300201000.IsNotEmpty Then
                    .Total10400300200000 += .cta_10400300201000.Total10400300201000
                End If
                If .cta_10400300202000.IsNotEmpty AndAlso .cta_10400300202000.Total10400300202000.IsNotEmpty Then
                    .Total10400300200000 += .cta_10400300202000.Total10400300202000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400300000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400300000000
                .Total10400300000000 = 0
                If .cta_10400300100000.IsNotEmpty AndAlso .cta_10400300100000.Total10400300100000.IsNotEmpty Then
                    .Total10400300000000 += .cta_10400300100000.Total10400300100000
                End If
                If .cta_10400300200000.IsNotEmpty AndAlso .cta_10400300200000.Total10400300200000.IsNotEmpty Then
                    .Total10400300000000 += .cta_10400300200000.Total10400300200000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400400000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400400000000.cta_10400400100000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400400000000.cta_10400400100000.cta_10400400101000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400400000000.cta_10400400100000.cta_10400400101000
                .Total10400400101000 = 0
                If .cta_10400400101010.IsNotEmpty Then
                    .Total10400400101000 += .cta_10400400101010
                End If
                If .cta_10400400101020.IsNotEmpty Then
                    .Total10400400101000 += .cta_10400400101020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400400000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400400000000.cta_10400400100000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400400000000.cta_10400400100000.cta_10400400102000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400400000000.cta_10400400100000.cta_10400400102000
                .Total10400400102000 = 0
                If .cta_10400400102010.IsNotEmpty Then
                    .Total10400400102000 += .cta_10400400102010
                End If
                If .cta_10400400102020.IsNotEmpty Then
                    .Total10400400102000 += .cta_10400400102020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400400000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400400000000.cta_10400400100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400400000000.cta_10400400100000
                .Total10400400100000 = 0
                If .cta_10400400101000.IsNotEmpty AndAlso .cta_10400400101000.Total10400400101000.IsNotEmpty Then
                    .Total10400400100000 += .cta_10400400101000.Total10400400101000
                End If
                If .cta_10400400102000.IsNotEmpty AndAlso .cta_10400400102000.Total10400400102000.IsNotEmpty Then
                    .Total10400400100000 += .cta_10400400102000.Total10400400102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400400000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400400000000.cta_10400400200000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400400000000.cta_10400400200000.cta_10400400201000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400400000000.cta_10400400200000.cta_10400400201000
                .Total10400400201000 = 0
                If .cta_10400400201010.IsNotEmpty Then
                    .Total10400400201000 += .cta_10400400201010
                End If
                If .cta_10400400201020.IsNotEmpty Then
                    .Total10400400201000 += .cta_10400400201020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400400000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400400000000.cta_10400400200000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400400000000.cta_10400400200000.cta_10400400202000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400400000000.cta_10400400200000.cta_10400400202000
                .Total10400400202000 = 0
                If .cta_10400400202010.IsNotEmpty Then
                    .Total10400400202000 += .cta_10400400202010
                End If
                If .cta_10400400202020.IsNotEmpty Then
                    .Total10400400202000 += .cta_10400400202020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400400000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400400000000.cta_10400400200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400400000000.cta_10400400200000
                .Total10400400200000 = 0
                If .cta_10400400201000.IsNotEmpty AndAlso .cta_10400400201000.Total10400400201000.IsNotEmpty Then
                    .Total10400400200000 += .cta_10400400201000.Total10400400201000
                End If
                If .cta_10400400202000.IsNotEmpty AndAlso .cta_10400400202000.Total10400400202000.IsNotEmpty Then
                    .Total10400400200000 += .cta_10400400202000.Total10400400202000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400400000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400400000000
                .Total10400400000000 = 0
                If .cta_10400400100000.IsNotEmpty AndAlso .cta_10400400100000.Total10400400100000.IsNotEmpty Then
                    .Total10400400000000 += .cta_10400400100000.Total10400400100000
                End If
                If .cta_10400400200000.IsNotEmpty AndAlso .cta_10400400200000.Total10400400200000.IsNotEmpty Then
                    .Total10400400000000 += .cta_10400400200000.Total10400400200000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400600000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400600000000.cta_10400600100000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400600000000.cta_10400600100000.cta_10400600101000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400600000000.cta_10400600100000.cta_10400600101000
                .Total10400600101000 = 0
                If .cta_10400600101010.IsNotEmpty Then
                    .Total10400600101000 += .cta_10400600101010
                End If
                If .cta_10400600101020.IsNotEmpty Then
                    .Total10400600101000 += .cta_10400600101020
                End If
                If .cta_10400600101030.IsNotEmpty Then
                    .Total10400600101000 += .cta_10400600101030
                End If
                If .cta_10400600101990.IsNotEmpty Then
                    .Total10400600101000 += .cta_10400600101990
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400600000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400600000000.cta_10400600100000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400600000000.cta_10400600100000.cta_10400600102000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400600000000.cta_10400600100000.cta_10400600102000
                .Total10400600102000 = 0
                If .cta_10400600102010.IsNotEmpty Then
                    .Total10400600102000 += .cta_10400600102010
                End If
                If .cta_10400600102020.IsNotEmpty Then
                    .Total10400600102000 += .cta_10400600102020
                End If
                If .cta_10400600102030.IsNotEmpty Then
                    .Total10400600102000 += .cta_10400600102030
                End If
                If .cta_10400600102990.IsNotEmpty Then
                    .Total10400600102000 += .cta_10400600102990
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400600000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400600000000.cta_10400600100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400600000000.cta_10400600100000
                .Total10400600100000 = 0
                If .cta_10400600101000.IsNotEmpty AndAlso .cta_10400600101000.Total10400600101000.IsNotEmpty Then
                    .Total10400600100000 += .cta_10400600101000.Total10400600101000
                End If
                If .cta_10400600102000.IsNotEmpty AndAlso .cta_10400600102000.Total10400600102000.IsNotEmpty Then
                    .Total10400600100000 += .cta_10400600102000.Total10400600102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400600000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400600000000
                .Total10400600000000 = 0
                If .cta_10400600100000.IsNotEmpty AndAlso .cta_10400600100000.Total10400600100000.IsNotEmpty Then
                    .Total10400600000000 += .cta_10400600100000.Total10400600100000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000.cta_10400700100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000.cta_10400700100000
                .Total10400700100000 = 0
                If .cta_10400700101000.IsNotEmpty Then
                    .Total10400700100000 += .cta_10400700101000
                End If
                If .cta_10400700102000.IsNotEmpty Then
                    .Total10400700100000 += .cta_10400700102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000.cta_10400700200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000.cta_10400700200000
                .Total10400700200000 = 0
                If .cta_10400700201000.IsNotEmpty Then
                    .Total10400700200000 += .cta_10400700201000
                End If
                If .cta_10400700202000.IsNotEmpty Then
                    .Total10400700200000 += .cta_10400700202000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000.cta_10400700300000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000.cta_10400700300000.cta_10400700301000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000.cta_10400700300000.cta_10400700301000
                .Total10400700301000 = 0
                If .cta_10400700301010.IsNotEmpty Then
                    .Total10400700301000 += .cta_10400700301010
                End If
                If .cta_10400700301020.IsNotEmpty Then
                    .Total10400700301000 += .cta_10400700301020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000.cta_10400700300000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000.cta_10400700300000.cta_10400700302000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000.cta_10400700300000.cta_10400700302000
                .Total10400700302000 = 0
                If .cta_10400700302010.IsNotEmpty Then
                    .Total10400700302000 += .cta_10400700302010
                End If
                If .cta_10400700302020.IsNotEmpty Then
                    .Total10400700302000 += .cta_10400700302020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000.cta_10400700300000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000.cta_10400700300000
                .Total10400700300000 = 0
                If .cta_10400700301000.IsNotEmpty AndAlso .cta_10400700301000.Total10400700301000.IsNotEmpty Then
                    .Total10400700300000 += .cta_10400700301000.Total10400700301000
                End If
                If .cta_10400700302000.IsNotEmpty AndAlso .cta_10400700302000.Total10400700302000.IsNotEmpty Then
                    .Total10400700300000 += .cta_10400700302000.Total10400700302000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000.cta_10400700400000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000.cta_10400700400000
                .Total10400700400000 = 0
                If .cta_10400700401000.IsNotEmpty Then
                    .Total10400700400000 += .cta_10400700401000
                End If
                If .cta_10400700402000.IsNotEmpty Then
                    .Total10400700400000 += .cta_10400700402000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000
                .Total10400700000000 = 0
                If .cta_10400700100000.IsNotEmpty AndAlso .cta_10400700100000.Total10400700100000.IsNotEmpty Then
                    .Total10400700000000 += .cta_10400700100000.Total10400700100000
                End If
                If .cta_10400700200000.IsNotEmpty AndAlso .cta_10400700200000.Total10400700200000.IsNotEmpty Then
                    .Total10400700000000 += .cta_10400700200000.Total10400700200000
                End If
                If .cta_10400700300000.IsNotEmpty AndAlso .cta_10400700300000.Total10400700300000.IsNotEmpty Then
                    .Total10400700000000 += .cta_10400700300000.Total10400700300000
                End If
                If .cta_10400700400000.IsNotEmpty AndAlso .cta_10400700400000.Total10400700400000.IsNotEmpty Then
                    .Total10400700000000 += .cta_10400700400000.Total10400700400000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400800100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400800100000
                .Total10400800100000 = 0
                If .cta_10400800101000.IsNotEmpty Then
                    .Total10400800100000 += .cta_10400800101000
                End If
                If .cta_10400800102000.IsNotEmpty Then
                    .Total10400800100000 += .cta_10400800102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400800200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400800200000
                .Total10400800200000 = 0
                If .cta_10400800201000.IsNotEmpty Then
                    .Total10400800200000 += .cta_10400800201000
                End If
                If .cta_10400800202000.IsNotEmpty Then
                    .Total10400800200000 += .cta_10400800202000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400800300000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400800300000.cta_10400800301000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400800300000.cta_10400800301000
                .Total10400800301000 = 0
                If .cta_10400800301010.IsNotEmpty Then
                    .Total10400800301000 += .cta_10400800301010
                End If
                If .cta_10400800301020.IsNotEmpty Then
                    .Total10400800301000 += .cta_10400800301020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400800300000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400800300000.cta_10400800302000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400800300000.cta_10400800302000
                .Total10400800302000 = 0
                If .cta_10400800302010.IsNotEmpty Then
                    .Total10400800302000 += .cta_10400800302010
                End If
                If .cta_10400800302020.IsNotEmpty Then
                    .Total10400800302000 += .cta_10400800302020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400800300000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400800300000
                .Total10400800300000 = 0
                If .cta_10400800301000.IsNotEmpty AndAlso .cta_10400800301000.Total10400800301000.IsNotEmpty Then
                    .Total10400800300000 += .cta_10400800301000.Total10400800301000
                End If
                If .cta_10400800302000.IsNotEmpty AndAlso .cta_10400800302000.Total10400800302000.IsNotEmpty Then
                    .Total10400800300000 += .cta_10400800302000.Total10400800302000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400800400000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400800400000
                .Total10400800400000 = 0
                If .cta_10400800401000.IsNotEmpty Then
                    .Total10400800400000 += .cta_10400800401000
                End If
                If .cta_10400800402000.IsNotEmpty Then
                    .Total10400800400000 += .cta_10400800402000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400800700000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400800700000
                .Total10400800700000 = 0
                If .cta_10400800701000.IsNotEmpty Then
                    .Total10400800700000 += .cta_10400800701000
                End If
                If .cta_10400800702000.IsNotEmpty Then
                    .Total10400800700000 += .cta_10400800702000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400800800000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400800800000.cta_10400800801000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400800800000.cta_10400800801000
                .Total10400800801000 = 0
                If .cta_10400800801010.IsNotEmpty Then
                    .Total10400800801000 += .cta_10400800801010
                End If
                If .cta_10400800801020.IsNotEmpty Then
                    .Total10400800801000 += .cta_10400800801020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400800800000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400800800000.cta_10400800802000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400800800000.cta_10400800802000
                .Total10400800802000 = 0
                If .cta_10400800802010.IsNotEmpty Then
                    .Total10400800802000 += .cta_10400800802010
                End If
                If .cta_10400800802020.IsNotEmpty Then
                    .Total10400800802000 += .cta_10400800802020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400800800000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400800800000
                .Total10400800800000 = 0
                If .cta_10400800801000.IsNotEmpty AndAlso .cta_10400800801000.Total10400800801000.IsNotEmpty Then
                    .Total10400800800000 += .cta_10400800801000.Total10400800801000
                End If
                If .cta_10400800802000.IsNotEmpty AndAlso .cta_10400800802000.Total10400800802000.IsNotEmpty Then
                    .Total10400800800000 += .cta_10400800802000.Total10400800802000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400801000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400801000000.cta_10400801001000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400801000000.cta_10400801001000
                .Total10400801001000 = 0
                If .cta_10400801001010.IsNotEmpty Then
                    .Total10400801001000 += .cta_10400801001010
                End If
                If .cta_10400801001990.IsNotEmpty Then
                    .Total10400801001000 += .cta_10400801001990
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400801000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400801000000.cta_10400801002000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400801000000.cta_10400801002000
                .Total10400801002000 = 0
                If .cta_10400801002010.IsNotEmpty Then
                    .Total10400801002000 += .cta_10400801002010
                End If
                If .cta_10400801002990.IsNotEmpty Then
                    .Total10400801002000 += .cta_10400801002990
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400801000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400801000000
                .Total10400801000000 = 0
                If .cta_10400801001000.IsNotEmpty AndAlso .cta_10400801001000.Total10400801001000.IsNotEmpty Then
                    .Total10400801000000 += .cta_10400801001000.Total10400801001000
                End If
                If .cta_10400801002000.IsNotEmpty AndAlso .cta_10400801002000.Total10400801002000.IsNotEmpty Then
                    .Total10400801000000 += .cta_10400801002000.Total10400801002000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400801200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400801200000
                .Total10400801200000 = 0
                If .cta_10400801201000.IsNotEmpty Then
                    .Total10400801200000 += .cta_10400801201000
                End If
                If .cta_10400801202000.IsNotEmpty Then
                    .Total10400801200000 += .cta_10400801202000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400809900000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400809900000
                .Total10400809900000 = 0
                If .cta_10400809901000.IsNotEmpty Then
                    .Total10400809900000 += .cta_10400809901000
                End If
                If .cta_10400809902000.IsNotEmpty Then
                    .Total10400809900000 += .cta_10400809902000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000
                .Total10400800000000 = 0
                If .cta_10400800100000.IsNotEmpty AndAlso .cta_10400800100000.Total10400800100000.IsNotEmpty Then
                    .Total10400800000000 += .cta_10400800100000.Total10400800100000
                End If
                If .cta_10400800200000.IsNotEmpty AndAlso .cta_10400800200000.Total10400800200000.IsNotEmpty Then
                    .Total10400800000000 += .cta_10400800200000.Total10400800200000
                End If
                If .cta_10400800300000.IsNotEmpty AndAlso .cta_10400800300000.Total10400800300000.IsNotEmpty Then
                    .Total10400800000000 += .cta_10400800300000.Total10400800300000
                End If
                If .cta_10400800400000.IsNotEmpty AndAlso .cta_10400800400000.Total10400800400000.IsNotEmpty Then
                    .Total10400800000000 += .cta_10400800400000.Total10400800400000
                End If
                If .cta_10400800700000.IsNotEmpty AndAlso .cta_10400800700000.Total10400800700000.IsNotEmpty Then
                    .Total10400800000000 += .cta_10400800700000.Total10400800700000
                End If
                If .cta_10400800800000.IsNotEmpty AndAlso .cta_10400800800000.Total10400800800000.IsNotEmpty Then
                    .Total10400800000000 += .cta_10400800800000.Total10400800800000
                End If
                If .cta_10400801000000.IsNotEmpty AndAlso .cta_10400801000000.Total10400801000000.IsNotEmpty Then
                    .Total10400800000000 += .cta_10400801000000.Total10400801000000
                End If
                If .cta_10400801200000.IsNotEmpty AndAlso .cta_10400801200000.Total10400801200000.IsNotEmpty Then
                    .Total10400800000000 += .cta_10400801200000.Total10400801200000
                End If
                If .cta_10400809900000.IsNotEmpty AndAlso .cta_10400809900000.Total10400809900000.IsNotEmpty Then
                    .Total10400800000000 += .cta_10400809900000.Total10400809900000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400900000000.cta_10400900300000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400900000000.cta_10400900300000
                .Total10400900300000 = 0
                If .cta_10400900301000.IsNotEmpty Then
                    .Total10400900300000 += .cta_10400900301000
                End If
                If .cta_10400900302000.IsNotEmpty Then
                    .Total10400900300000 += .cta_10400900302000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400900000000.cta_10400900400000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400900000000.cta_10400900400000
                .Total10400900400000 = 0
                If .cta_10400900401000.IsNotEmpty Then
                    .Total10400900400000 += .cta_10400900401000
                End If
                If .cta_10400900402000.IsNotEmpty Then
                    .Total10400900400000 += .cta_10400900402000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400900000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10400900000000
                .Total10400900000000 = 0
                If .cta_10400900300000.IsNotEmpty AndAlso .cta_10400900300000.Total10400900300000.IsNotEmpty Then
                    .Total10400900000000 += .cta_10400900300000.Total10400900300000
                End If
                If .cta_10400900400000.IsNotEmpty AndAlso .cta_10400900400000.Total10400900400000.IsNotEmpty Then
                    .Total10400900000000 += .cta_10400900400000.Total10400900400000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000.cta_10401000200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000.cta_10401000200000
                .Total10401000200000 = 0
                If .cta_10401000201000.IsNotEmpty Then
                    .Total10401000200000 += .cta_10401000201000
                End If
                If .cta_10401000202000.IsNotEmpty Then
                    .Total10401000200000 += .cta_10401000202000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000.cta_10401000300000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000.cta_10401000300000.cta_10401000301000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000.cta_10401000300000.cta_10401000301000
                .Total10401000301000 = 0
                If .cta_10401000301010.IsNotEmpty Then
                    .Total10401000301000 += .cta_10401000301010
                End If
                If .cta_10401000301020.IsNotEmpty Then
                    .Total10401000301000 += .cta_10401000301020
                End If
                If .cta_10401000301030.IsNotEmpty Then
                    .Total10401000301000 += .cta_10401000301030
                End If
                If .cta_10401000301040.IsNotEmpty Then
                    .Total10401000301000 += .cta_10401000301040
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000.cta_10401000300000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000.cta_10401000300000.cta_10401000302000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000.cta_10401000300000.cta_10401000302000
                .Total10401000302000 = 0
                If .cta_10401000302010.IsNotEmpty Then
                    .Total10401000302000 += .cta_10401000302010
                End If
                If .cta_10401000302020.IsNotEmpty Then
                    .Total10401000302000 += .cta_10401000302020
                End If
                If .cta_10401000302030.IsNotEmpty Then
                    .Total10401000302000 += .cta_10401000302030
                End If
                If .cta_10401000302040.IsNotEmpty Then
                    .Total10401000302000 += .cta_10401000302040
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000.cta_10401000300000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000.cta_10401000300000
                .Total10401000300000 = 0
                If .cta_10401000301000.IsNotEmpty AndAlso .cta_10401000301000.Total10401000301000.IsNotEmpty Then
                    .Total10401000300000 += .cta_10401000301000.Total10401000301000
                End If
                If .cta_10401000302000.IsNotEmpty AndAlso .cta_10401000302000.Total10401000302000.IsNotEmpty Then
                    .Total10401000300000 += .cta_10401000302000.Total10401000302000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000.cta_10401000500000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000.cta_10401000500000
                .Total10401000500000 = 0
                If .cta_10401000501000.IsNotEmpty Then
                    .Total10401000500000 += .cta_10401000501000
                End If
                If .cta_10401000502000.IsNotEmpty Then
                    .Total10401000500000 += .cta_10401000502000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000.cta_10401000700000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000.cta_10401000700000
                .Total10401000700000 = 0
                If .cta_10401000701000.IsNotEmpty Then
                    .Total10401000700000 += .cta_10401000701000
                End If
                If .cta_10401000702000.IsNotEmpty Then
                    .Total10401000700000 += .cta_10401000702000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000.cta_10401000900000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000.cta_10401000900000
                .Total10401000900000 = 0
                If .cta_10401000901000.IsNotEmpty Then
                    .Total10401000900000 += .cta_10401000901000
                End If
                If .cta_10401000902000.IsNotEmpty Then
                    .Total10401000900000 += .cta_10401000902000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000
                .Total10401000000000 = 0
                If .cta_10401000200000.IsNotEmpty AndAlso .cta_10401000200000.Total10401000200000.IsNotEmpty Then
                    .Total10401000000000 += .cta_10401000200000.Total10401000200000
                End If
                If .cta_10401000300000.IsNotEmpty AndAlso .cta_10401000300000.Total10401000300000.IsNotEmpty Then
                    .Total10401000000000 += .cta_10401000300000.Total10401000300000
                End If
                If .cta_10401000500000.IsNotEmpty AndAlso .cta_10401000500000.Total10401000500000.IsNotEmpty Then
                    .Total10401000000000 += .cta_10401000500000.Total10401000500000
                End If
                If .cta_10401000700000.IsNotEmpty AndAlso .cta_10401000700000.Total10401000700000.IsNotEmpty Then
                    .Total10401000000000 += .cta_10401000700000.Total10401000700000
                End If
                If .cta_10401000900000.IsNotEmpty AndAlso .cta_10401000900000.Total10401000900000.IsNotEmpty Then
                    .Total10401000000000 += .cta_10401000900000.Total10401000900000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10400000000000
                .Total10400000000000 = 0
                If .cta_10400200000000.IsNotEmpty AndAlso .cta_10400200000000.Total10400200000000.IsNotEmpty Then
                    .Total10400000000000 += .cta_10400200000000.Total10400200000000
                End If
                If .cta_10400300000000.IsNotEmpty AndAlso .cta_10400300000000.Total10400300000000.IsNotEmpty Then
                    .Total10400000000000 += .cta_10400300000000.Total10400300000000
                End If
                If .cta_10400400000000.IsNotEmpty AndAlso .cta_10400400000000.Total10400400000000.IsNotEmpty Then
                    .Total10400000000000 += .cta_10400400000000.Total10400400000000
                End If
                If .cta_10400600000000.IsNotEmpty AndAlso .cta_10400600000000.Total10400600000000.IsNotEmpty Then
                    .Total10400000000000 += .cta_10400600000000.Total10400600000000
                End If
                If .cta_10400700000000.IsNotEmpty AndAlso .cta_10400700000000.Total10400700000000.IsNotEmpty Then
                    .Total10400000000000 += .cta_10400700000000.Total10400700000000
                End If
                If .cta_10400800000000.IsNotEmpty AndAlso .cta_10400800000000.Total10400800000000.IsNotEmpty Then
                    .Total10400000000000 += .cta_10400800000000.Total10400800000000
                End If
                If .cta_10400900000000.IsNotEmpty AndAlso .cta_10400900000000.Total10400900000000.IsNotEmpty Then
                    .Total10400000000000 += .cta_10400900000000.Total10400900000000
                End If
                If .cta_10401000000000.IsNotEmpty AndAlso .cta_10401000000000.Total10401000000000.IsNotEmpty Then
                    .Total10400000000000 += .cta_10401000000000.Total10401000000000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10500000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100100000
                .Total10500100100000 = 0
                If .cta_10500100101000.IsNotEmpty Then
                    .Total10500100100000 += .cta_10500100101000
                End If
                If .cta_10500100102000.IsNotEmpty Then
                    .Total10500100100000 += .cta_10500100102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10500000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000
                .Total10500100000000 = 0
                If .cta_10500100100000.IsNotEmpty AndAlso .cta_10500100100000.Total10500100100000.IsNotEmpty Then
                    .Total10500100000000 += .cta_10500100100000.Total10500100100000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10500000000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10500000000000
                .Total10500000000000 = 0
                If .cta_10500100000000.IsNotEmpty AndAlso .cta_10500100000000.Total10500100000000.IsNotEmpty Then
                    .Total10500000000000 += .cta_10500100000000.Total10500100000000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100100000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100100000.cta_10600100101000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100100000.cta_10600100101000
                .Total10600100101000 = 0
                If .cta_10600100101010.IsNotEmpty Then
                    .Total10600100101000 += .cta_10600100101010
                End If
                If .cta_10600100101020.IsNotEmpty Then
                    .Total10600100101000 += .cta_10600100101020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100100000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100100000.cta_10600100102000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100100000.cta_10600100102000
                .Total10600100102000 = 0
                If .cta_10600100102010.IsNotEmpty Then
                    .Total10600100102000 += .cta_10600100102010
                End If
                If .cta_10600100102020.IsNotEmpty Then
                    .Total10600100102000 += .cta_10600100102020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100100000
                .Total10600100100000 = 0
                If .cta_10600100101000.IsNotEmpty AndAlso .cta_10600100101000.Total10600100101000.IsNotEmpty Then
                    .Total10600100100000 += .cta_10600100101000.Total10600100101000
                End If
                If .cta_10600100102000.IsNotEmpty AndAlso .cta_10600100102000.Total10600100102000.IsNotEmpty Then
                    .Total10600100100000 += .cta_10600100102000.Total10600100102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000
                .Total10600100000000 = 0
                If .cta_10600100100000.IsNotEmpty AndAlso .cta_10600100100000.Total10600100100000.IsNotEmpty Then
                    .Total10600100000000 += .cta_10600100100000.Total10600100100000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600200000000.cta_10600200100000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600200000000.cta_10600200100000.cta_10600200101000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600200000000.cta_10600200100000.cta_10600200101000
                .Total10600200101000 = 0
                If .cta_10600200101020.IsNotEmpty Then
                    .Total10600200101000 += .cta_10600200101020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600200000000.cta_10600200100000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600200000000.cta_10600200100000.cta_10600200102000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600200000000.cta_10600200100000.cta_10600200102000
                .Total10600200102000 = 0
                If .cta_10600200102020.IsNotEmpty Then
                    .Total10600200102000 += .cta_10600200102020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600200000000.cta_10600200100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600200000000.cta_10600200100000
                .Total10600200100000 = 0
                If .cta_10600200101000.IsNotEmpty AndAlso .cta_10600200101000.Total10600200101000.IsNotEmpty Then
                    .Total10600200100000 += .cta_10600200101000.Total10600200101000
                End If
                If .cta_10600200102000.IsNotEmpty AndAlso .cta_10600200102000.Total10600200102000.IsNotEmpty Then
                    .Total10600200100000 += .cta_10600200102000.Total10600200102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600200000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600200000000
                .Total10600200000000 = 0
                If .cta_10600200100000.IsNotEmpty AndAlso .cta_10600200100000.Total10600200100000.IsNotEmpty Then
                    .Total10600200000000 += .cta_10600200100000.Total10600200100000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600300000000.cta_10600300100000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600300000000.cta_10600300100000.cta_10600300101000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600300000000.cta_10600300100000.cta_10600300101000
                .Total10600300101000 = 0
                If .cta_10600300101010.IsNotEmpty Then
                    .Total10600300101000 += .cta_10600300101010
                End If
                If .cta_10600300101020.IsNotEmpty Then
                    .Total10600300101000 += .cta_10600300101020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600300000000.cta_10600300100000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600300000000.cta_10600300100000.cta_10600300102000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600300000000.cta_10600300100000.cta_10600300102000
                .Total10600300102000 = 0
                If .cta_10600300102010.IsNotEmpty Then
                    .Total10600300102000 += .cta_10600300102010
                End If
                If .cta_10600300102020.IsNotEmpty Then
                    .Total10600300102000 += .cta_10600300102020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600300000000.cta_10600300100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600300000000.cta_10600300100000
                .Total10600300100000 = 0
                If .cta_10600300101000.IsNotEmpty AndAlso .cta_10600300101000.Total10600300101000.IsNotEmpty Then
                    .Total10600300100000 += .cta_10600300101000.Total10600300101000
                End If
                If .cta_10600300102000.IsNotEmpty AndAlso .cta_10600300102000.Total10600300102000.IsNotEmpty Then
                    .Total10600300100000 += .cta_10600300102000.Total10600300102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600300000000.cta_10600300200000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600300000000.cta_10600300200000.cta_10600300201000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600300000000.cta_10600300200000.cta_10600300201000
                .Total10600300201000 = 0
                If .cta_10600300201010.IsNotEmpty Then
                    .Total10600300201000 += .cta_10600300201010
                End If
                If .cta_10600300201020.IsNotEmpty Then
                    .Total10600300201000 += .cta_10600300201020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600300000000.cta_10600300200000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600300000000.cta_10600300200000.cta_10600300202000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600300000000.cta_10600300200000.cta_10600300202000
                .Total10600300202000 = 0
                If .cta_10600300202010.IsNotEmpty Then
                    .Total10600300202000 += .cta_10600300202010
                End If
                If .cta_10600300202020.IsNotEmpty Then
                    .Total10600300202000 += .cta_10600300202020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600300000000.cta_10600300200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600300000000.cta_10600300200000
                .Total10600300200000 = 0
                If .cta_10600300201000.IsNotEmpty AndAlso .cta_10600300201000.Total10600300201000.IsNotEmpty Then
                    .Total10600300200000 += .cta_10600300201000.Total10600300201000
                End If
                If .cta_10600300202000.IsNotEmpty AndAlso .cta_10600300202000.Total10600300202000.IsNotEmpty Then
                    .Total10600300200000 += .cta_10600300202000.Total10600300202000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600300000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600300000000
                .Total10600300000000 = 0
                If .cta_10600300100000.IsNotEmpty AndAlso .cta_10600300100000.Total10600300100000.IsNotEmpty Then
                    .Total10600300000000 += .cta_10600300100000.Total10600300100000
                End If
                If .cta_10600300200000.IsNotEmpty AndAlso .cta_10600300200000.Total10600300200000.IsNotEmpty Then
                    .Total10600300000000 += .cta_10600300200000.Total10600300200000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600400000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600400000000.cta_10600400100000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600400000000.cta_10600400100000.cta_10600400101000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600400000000.cta_10600400100000.cta_10600400101000
                .Total10600400101000 = 0
                If .cta_10600400101010.IsNotEmpty Then
                    .Total10600400101000 += .cta_10600400101010
                End If
                If .cta_10600400101020.IsNotEmpty Then
                    .Total10600400101000 += .cta_10600400101020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600400000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600400000000.cta_10600400100000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600400000000.cta_10600400100000.cta_10600400102000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600400000000.cta_10600400100000.cta_10600400102000
                .Total10600400102000 = 0
                If .cta_10600400102010.IsNotEmpty Then
                    .Total10600400102000 += .cta_10600400102010
                End If
                If .cta_10600400102020.IsNotEmpty Then
                    .Total10600400102000 += .cta_10600400102020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600400000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600400000000.cta_10600400100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600400000000.cta_10600400100000
                .Total10600400100000 = 0
                If .cta_10600400101000.IsNotEmpty AndAlso .cta_10600400101000.Total10600400101000.IsNotEmpty Then
                    .Total10600400100000 += .cta_10600400101000.Total10600400101000
                End If
                If .cta_10600400102000.IsNotEmpty AndAlso .cta_10600400102000.Total10600400102000.IsNotEmpty Then
                    .Total10600400100000 += .cta_10600400102000.Total10600400102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600400000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600400000000.cta_10600400200000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600400000000.cta_10600400200000.cta_10600400201000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600400000000.cta_10600400200000.cta_10600400201000
                .Total10600400201000 = 0
                If .cta_10600400201010.IsNotEmpty Then
                    .Total10600400201000 += .cta_10600400201010
                End If
                If .cta_10600400201020.IsNotEmpty Then
                    .Total10600400201000 += .cta_10600400201020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600400000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600400000000.cta_10600400200000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600400000000.cta_10600400200000.cta_10600400202000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600400000000.cta_10600400200000.cta_10600400202000
                .Total10600400202000 = 0
                If .cta_10600400202010.IsNotEmpty Then
                    .Total10600400202000 += .cta_10600400202010
                End If
                If .cta_10600400202020.IsNotEmpty Then
                    .Total10600400202000 += .cta_10600400202020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600400000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600400000000.cta_10600400200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600400000000.cta_10600400200000
                .Total10600400200000 = 0
                If .cta_10600400201000.IsNotEmpty AndAlso .cta_10600400201000.Total10600400201000.IsNotEmpty Then
                    .Total10600400200000 += .cta_10600400201000.Total10600400201000
                End If
                If .cta_10600400202000.IsNotEmpty AndAlso .cta_10600400202000.Total10600400202000.IsNotEmpty Then
                    .Total10600400200000 += .cta_10600400202000.Total10600400202000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600400000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.cta_10600400000000
                .Total10600400000000 = 0
                If .cta_10600400100000.IsNotEmpty AndAlso .cta_10600400100000.Total10600400100000.IsNotEmpty Then
                    .Total10600400000000 += .cta_10600400100000.Total10600400100000
                End If
                If .cta_10600400200000.IsNotEmpty AndAlso .cta_10600400200000.Total10600400200000.IsNotEmpty Then
                    .Total10600400000000 += .cta_10600400200000.Total10600400200000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10600000000000
                .Total10600000000000 = 0
                If .cta_10600100000000.IsNotEmpty AndAlso .cta_10600100000000.Total10600100000000.IsNotEmpty Then
                    .Total10600000000000 += .cta_10600100000000.Total10600100000000
                End If
                If .cta_10600200000000.IsNotEmpty AndAlso .cta_10600200000000.Total10600200000000.IsNotEmpty Then
                    .Total10600000000000 += .cta_10600200000000.Total10600200000000
                End If
                If .cta_10600300000000.IsNotEmpty AndAlso .cta_10600300000000.Total10600300000000.IsNotEmpty Then
                    .Total10600000000000 += .cta_10600300000000.Total10600300000000
                End If
                If .cta_10600400000000.IsNotEmpty AndAlso .cta_10600400000000.Total10600400000000.IsNotEmpty Then
                    .Total10600000000000 += .cta_10600400000000.Total10600400000000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100100000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100100000.cta_10700100101000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100100000.cta_10700100101000
                .Total10700100101000 = 0
                If .cta_10700100101010.IsNotEmpty Then
                    .Total10700100101000 += .cta_10700100101010
                End If
                If .cta_10700100101020.IsNotEmpty Then
                    .Total10700100101000 += .cta_10700100101020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100100000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100100000.cta_10700100102000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100100000.cta_10700100102000
                .Total10700100102000 = 0
                If .cta_10700100102010.IsNotEmpty Then
                    .Total10700100102000 += .cta_10700100102010
                End If
                If .cta_10700100102020.IsNotEmpty Then
                    .Total10700100102000 += .cta_10700100102020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100100000
                .Total10700100100000 = 0
                If .cta_10700100101000.IsNotEmpty AndAlso .cta_10700100101000.Total10700100101000.IsNotEmpty Then
                    .Total10700100100000 += .cta_10700100101000.Total10700100101000
                End If
                If .cta_10700100102000.IsNotEmpty AndAlso .cta_10700100102000.Total10700100102000.IsNotEmpty Then
                    .Total10700100100000 += .cta_10700100102000.Total10700100102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100200000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100200000.cta_10700100201000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100200000.cta_10700100201000
                .Total10700100201000 = 0
                If .cta_10700100201010.IsNotEmpty Then
                    .Total10700100201000 += .cta_10700100201010
                End If
                If .cta_10700100201020.IsNotEmpty Then
                    .Total10700100201000 += .cta_10700100201020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100200000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100200000.cta_10700100202000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100200000.cta_10700100202000
                .Total10700100202000 = 0
                If .cta_10700100202010.IsNotEmpty Then
                    .Total10700100202000 += .cta_10700100202010
                End If
                If .cta_10700100202020.IsNotEmpty Then
                    .Total10700100202000 += .cta_10700100202020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100200000
                .Total10700100200000 = 0
                If .cta_10700100201000.IsNotEmpty AndAlso .cta_10700100201000.Total10700100201000.IsNotEmpty Then
                    .Total10700100200000 += .cta_10700100201000.Total10700100201000
                End If
                If .cta_10700100202000.IsNotEmpty AndAlso .cta_10700100202000.Total10700100202000.IsNotEmpty Then
                    .Total10700100200000 += .cta_10700100202000.Total10700100202000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100300000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100300000.cta_10700100301000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100300000.cta_10700100301000
                .Total10700100301000 = 0
                If .cta_10700100301010.IsNotEmpty Then
                    .Total10700100301000 += .cta_10700100301010
                End If
                If .cta_10700100301020.IsNotEmpty Then
                    .Total10700100301000 += .cta_10700100301020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100300000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100300000.cta_10700100302000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100300000.cta_10700100302000
                .Total10700100302000 = 0
                If .cta_10700100302010.IsNotEmpty Then
                    .Total10700100302000 += .cta_10700100302010
                End If
                If .cta_10700100302020.IsNotEmpty Then
                    .Total10700100302000 += .cta_10700100302020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100300000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100300000
                .Total10700100300000 = 0
                If .cta_10700100301000.IsNotEmpty AndAlso .cta_10700100301000.Total10700100301000.IsNotEmpty Then
                    .Total10700100300000 += .cta_10700100301000.Total10700100301000
                End If
                If .cta_10700100302000.IsNotEmpty AndAlso .cta_10700100302000.Total10700100302000.IsNotEmpty Then
                    .Total10700100300000 += .cta_10700100302000.Total10700100302000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100400000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100400000.cta_10700100401000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100400000.cta_10700100401000
                .Total10700100401000 = 0
                If .cta_10700100401010.IsNotEmpty Then
                    .Total10700100401000 += .cta_10700100401010
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100400000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100400000.cta_10700100402000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100400000.cta_10700100402000
                .Total10700100402000 = 0
                If .cta_10700100402010.IsNotEmpty Then
                    .Total10700100402000 += .cta_10700100402010
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100400000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100400000
                .Total10700100400000 = 0
                If .cta_10700100401000.IsNotEmpty AndAlso .cta_10700100401000.Total10700100401000.IsNotEmpty Then
                    .Total10700100400000 += .cta_10700100401000.Total10700100401000
                End If
                If .cta_10700100402000.IsNotEmpty AndAlso .cta_10700100402000.Total10700100402000.IsNotEmpty Then
                    .Total10700100400000 += .cta_10700100402000.Total10700100402000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000
                .Total10700100000000 = 0
                If .cta_10700100100000.IsNotEmpty AndAlso .cta_10700100100000.Total10700100100000.IsNotEmpty Then
                    .Total10700100000000 += .cta_10700100100000.Total10700100100000
                End If
                If .cta_10700100200000.IsNotEmpty AndAlso .cta_10700100200000.Total10700100200000.IsNotEmpty Then
                    .Total10700100000000 += .cta_10700100200000.Total10700100200000
                End If
                If .cta_10700100300000.IsNotEmpty AndAlso .cta_10700100300000.Total10700100300000.IsNotEmpty Then
                    .Total10700100000000 += .cta_10700100300000.Total10700100300000
                End If
                If .cta_10700100400000.IsNotEmpty AndAlso .cta_10700100400000.Total10700100400000.IsNotEmpty Then
                    .Total10700100000000 += .cta_10700100400000.Total10700100400000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700400000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700400000000.cta_10700400100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700400000000.cta_10700400100000
                .Total10700400100000 = 0
                If .cta_10700400101000.IsNotEmpty Then
                    .Total10700400100000 += .cta_10700400101000
                End If
                If .cta_10700400102000.IsNotEmpty Then
                    .Total10700400100000 += .cta_10700400102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700400000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700400000000.cta_10700400200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700400000000.cta_10700400200000
                .Total10700400200000 = 0
                If .cta_10700400201000.IsNotEmpty Then
                    .Total10700400200000 += .cta_10700400201000
                End If
                If .cta_10700400202000.IsNotEmpty Then
                    .Total10700400200000 += .cta_10700400202000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700400000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700400000000
                .Total10700400000000 = 0
                If .cta_10700400100000.IsNotEmpty AndAlso .cta_10700400100000.Total10700400100000.IsNotEmpty Then
                    .Total10700400000000 += .cta_10700400100000.Total10700400100000
                End If
                If .cta_10700400200000.IsNotEmpty AndAlso .cta_10700400200000.Total10700400200000.IsNotEmpty Then
                    .Total10700400000000 += .cta_10700400200000.Total10700400200000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700700000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700700000000.cta_10700700100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700700000000.cta_10700700100000
                .Total10700700100000 = 0
                If .cta_10700700101000.IsNotEmpty Then
                    .Total10700700100000 += .cta_10700700101000
                End If
                If .cta_10700700102000.IsNotEmpty Then
                    .Total10700700100000 += .cta_10700700102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700700000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700700000000
                .Total10700700000000 = 0
                If .cta_10700700100000.IsNotEmpty AndAlso .cta_10700700100000.Total10700700100000.IsNotEmpty Then
                    .Total10700700000000 += .cta_10700700100000.Total10700700100000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700800000000.cta_10700800100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700800000000.cta_10700800100000
                .Total10700800100000 = 0
                If .cta_10700800101000.IsNotEmpty Then
                    .Total10700800100000 += .cta_10700800101000
                End If
                If .cta_10700800102000.IsNotEmpty Then
                    .Total10700800100000 += .cta_10700800102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700800000000.cta_10700800200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700800000000.cta_10700800200000
                .Total10700800200000 = 0
                If .cta_10700800201000.IsNotEmpty Then
                    .Total10700800200000 += .cta_10700800201000
                End If
                If .cta_10700800202000.IsNotEmpty Then
                    .Total10700800200000 += .cta_10700800202000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700800000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700800000000
                .Total10700800000000 = 0
                If .cta_10700800100000.IsNotEmpty AndAlso .cta_10700800100000.Total10700800100000.IsNotEmpty Then
                    .Total10700800000000 += .cta_10700800100000.Total10700800100000
                End If
                If .cta_10700800200000.IsNotEmpty AndAlso .cta_10700800200000.Total10700800200000.IsNotEmpty Then
                    .Total10700800000000 += .cta_10700800200000.Total10700800200000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000.cta_10700900100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000.cta_10700900100000
                .Total10700900100000 = 0
                If .cta_10700900101000.IsNotEmpty Then
                    .Total10700900100000 += .cta_10700900101000
                End If
                If .cta_10700900102000.IsNotEmpty Then
                    .Total10700900100000 += .cta_10700900102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000.cta_10700900200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000.cta_10700900200000
                .Total10700900200000 = 0
                If .cta_10700900201000.IsNotEmpty Then
                    .Total10700900200000 += .cta_10700900201000
                End If
                If .cta_10700900202000.IsNotEmpty Then
                    .Total10700900200000 += .cta_10700900202000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000.cta_10700900300000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000.cta_10700900300000
                .Total10700900300000 = 0
                If .cta_10700900301000.IsNotEmpty Then
                    .Total10700900300000 += .cta_10700900301000
                End If
                If .cta_10700900302000.IsNotEmpty Then
                    .Total10700900300000 += .cta_10700900302000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000.cta_10700900400000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000.cta_10700900400000
                .Total10700900400000 = 0
                If .cta_10700900401000.IsNotEmpty Then
                    .Total10700900400000 += .cta_10700900401000
                End If
                If .cta_10700900402000.IsNotEmpty Then
                    .Total10700900400000 += .cta_10700900402000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000.cta_10700900800000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000.cta_10700900800000
                .Total10700900800000 = 0
                If .cta_10700900801000.IsNotEmpty Then
                    .Total10700900800000 += .cta_10700900801000
                End If
                If .cta_10700900802000.IsNotEmpty Then
                    .Total10700900800000 += .cta_10700900802000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000.cta_10700900900000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000.cta_10700900900000
                .Total10700900900000 = 0
                If .cta_10700900901000.IsNotEmpty Then
                    .Total10700900900000 += .cta_10700900901000
                End If
                If .cta_10700900902000.IsNotEmpty Then
                    .Total10700900900000 += .cta_10700900902000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000
                .Total10700900000000 = 0
                If .cta_10700900100000.IsNotEmpty AndAlso .cta_10700900100000.Total10700900100000.IsNotEmpty Then
                    .Total10700900000000 += .cta_10700900100000.Total10700900100000
                End If
                If .cta_10700900200000.IsNotEmpty AndAlso .cta_10700900200000.Total10700900200000.IsNotEmpty Then
                    .Total10700900000000 += .cta_10700900200000.Total10700900200000
                End If
                If .cta_10700900300000.IsNotEmpty AndAlso .cta_10700900300000.Total10700900300000.IsNotEmpty Then
                    .Total10700900000000 += .cta_10700900300000.Total10700900300000
                End If
                If .cta_10700900400000.IsNotEmpty AndAlso .cta_10700900400000.Total10700900400000.IsNotEmpty Then
                    .Total10700900000000 += .cta_10700900400000.Total10700900400000
                End If
                If .cta_10700900800000.IsNotEmpty AndAlso .cta_10700900800000.Total10700900800000.IsNotEmpty Then
                    .Total10700900000000 += .cta_10700900800000.Total10700900800000
                End If
                If .cta_10700900900000.IsNotEmpty AndAlso .cta_10700900900000.Total10700900900000.IsNotEmpty Then
                    .Total10700900000000 += .cta_10700900900000.Total10700900900000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10700000000000
                .Total10700000000000 = 0
                If .cta_10700100000000.IsNotEmpty AndAlso .cta_10700100000000.Total10700100000000.IsNotEmpty Then
                    .Total10700000000000 += .cta_10700100000000.Total10700100000000
                End If
                If .cta_10700400000000.IsNotEmpty AndAlso .cta_10700400000000.Total10700400000000.IsNotEmpty Then
                    .Total10700000000000 += .cta_10700400000000.Total10700400000000
                End If
                If .cta_10700700000000.IsNotEmpty AndAlso .cta_10700700000000.Total10700700000000.IsNotEmpty Then
                    .Total10700000000000 += .cta_10700700000000.Total10700700000000
                End If
                If .cta_10700800000000.IsNotEmpty AndAlso .cta_10700800000000.Total10700800000000.IsNotEmpty Then
                    .Total10700000000000 += .cta_10700800000000.Total10700800000000
                End If
                If .cta_10700900000000.IsNotEmpty AndAlso .cta_10700900000000.Total10700900000000.IsNotEmpty Then
                    .Total10700000000000 += .cta_10700900000000.Total10700900000000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800200000000.cta_10800200100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800200000000.cta_10800200100000
                .Total10800200100000 = 0
                If .cta_10800200101000.IsNotEmpty Then
                    .Total10800200100000 += .cta_10800200101000
                End If
                If .cta_10800200102000.IsNotEmpty Then
                    .Total10800200100000 += .cta_10800200102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800200000000.cta_10800200300000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800200000000.cta_10800200300000
                .Total10800200300000 = 0
                If .cta_10800200301000.IsNotEmpty Then
                    .Total10800200300000 += .cta_10800200301000
                End If
                If .cta_10800200302000.IsNotEmpty Then
                    .Total10800200300000 += .cta_10800200302000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800200000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800200000000
                .Total10800200000000 = 0
                If .cta_10800200100000.IsNotEmpty AndAlso .cta_10800200100000.Total10800200100000.IsNotEmpty Then
                    .Total10800200000000 += .cta_10800200100000.Total10800200100000
                End If
                If .cta_10800200300000.IsNotEmpty AndAlso .cta_10800200300000.Total10800200300000.IsNotEmpty Then
                    .Total10800200000000 += .cta_10800200300000.Total10800200300000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800300000000.cta_10800300100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800300000000.cta_10800300100000
                .Total10800300100000 = 0
                If .cta_10800300101000.IsNotEmpty Then
                    .Total10800300100000 += .cta_10800300101000
                End If
                If .cta_10800300102000.IsNotEmpty Then
                    .Total10800300100000 += .cta_10800300102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800300000000.cta_10800300200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800300000000.cta_10800300200000
                .Total10800300200000 = 0
                If .cta_10800300201000.IsNotEmpty Then
                    .Total10800300200000 += .cta_10800300201000
                End If
                If .cta_10800300202000.IsNotEmpty Then
                    .Total10800300200000 += .cta_10800300202000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800300000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800300000000
                .Total10800300000000 = 0
                If .cta_10800300100000.IsNotEmpty AndAlso .cta_10800300100000.Total10800300100000.IsNotEmpty Then
                    .Total10800300000000 += .cta_10800300100000.Total10800300100000
                End If
                If .cta_10800300200000.IsNotEmpty AndAlso .cta_10800300200000.Total10800300200000.IsNotEmpty Then
                    .Total10800300000000 += .cta_10800300200000.Total10800300200000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800400000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800400000000.cta_10800400100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800400000000.cta_10800400100000
                .Total10800400100000 = 0
                If .cta_10800400101000.IsNotEmpty Then
                    .Total10800400100000 += .cta_10800400101000
                End If
                If .cta_10800400102000.IsNotEmpty Then
                    .Total10800400100000 += .cta_10800400102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800400000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800400000000.cta_10800400300000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800400000000.cta_10800400300000
                .Total10800400300000 = 0
                If .cta_10800400301000.IsNotEmpty Then
                    .Total10800400300000 += .cta_10800400301000
                End If
                If .cta_10800400302000.IsNotEmpty Then
                    .Total10800400300000 += .cta_10800400302000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800400000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800400000000
                .Total10800400000000 = 0
                If .cta_10800400100000.IsNotEmpty AndAlso .cta_10800400100000.Total10800400100000.IsNotEmpty Then
                    .Total10800400000000 += .cta_10800400100000.Total10800400100000
                End If
                If .cta_10800400300000.IsNotEmpty AndAlso .cta_10800400300000.Total10800400300000.IsNotEmpty Then
                    .Total10800400000000 += .cta_10800400300000.Total10800400300000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502100000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502100000.cta_10800502101000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502100000.cta_10800502101000
                .Total10800502101000 = 0
                If .cta_10800502101010.IsNotEmpty Then
                    .Total10800502101000 += .cta_10800502101010
                End If
                If .cta_10800502101020.IsNotEmpty Then
                    .Total10800502101000 += .cta_10800502101020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502100000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502100000.cta_10800502102000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502100000.cta_10800502102000
                .Total10800502102000 = 0
                If .cta_10800502102010.IsNotEmpty Then
                    .Total10800502102000 += .cta_10800502102010
                End If
                If .cta_10800502102020.IsNotEmpty Then
                    .Total10800502102000 += .cta_10800502102020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502100000
                .Total10800502100000 = 0
                If .cta_10800502101000.IsNotEmpty AndAlso .cta_10800502101000.Total10800502101000.IsNotEmpty Then
                    .Total10800502100000 += .cta_10800502101000.Total10800502101000
                End If
                If .cta_10800502102000.IsNotEmpty AndAlso .cta_10800502102000.Total10800502102000.IsNotEmpty Then
                    .Total10800502100000 += .cta_10800502102000.Total10800502102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502200000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502200000.cta_10800502201000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502200000.cta_10800502201000
                .Total10800502201000 = 0
                If .cta_10800502201010.IsNotEmpty Then
                    .Total10800502201000 += .cta_10800502201010
                End If
                If .cta_10800502201020.IsNotEmpty Then
                    .Total10800502201000 += .cta_10800502201020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502200000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502200000.cta_10800502202000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502200000.cta_10800502202000
                .Total10800502202000 = 0
                If .cta_10800502202010.IsNotEmpty Then
                    .Total10800502202000 += .cta_10800502202010
                End If
                If .cta_10800502202020.IsNotEmpty Then
                    .Total10800502202000 += .cta_10800502202020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502200000
                .Total10800502200000 = 0
                If .cta_10800502201000.IsNotEmpty AndAlso .cta_10800502201000.Total10800502201000.IsNotEmpty Then
                    .Total10800502200000 += .cta_10800502201000.Total10800502201000
                End If
                If .cta_10800502202000.IsNotEmpty AndAlso .cta_10800502202000.Total10800502202000.IsNotEmpty Then
                    .Total10800502200000 += .cta_10800502202000.Total10800502202000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502300000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502300000.cta_10800502301000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502300000.cta_10800502301000
                .Total10800502301000 = 0
                If .cta_10800502301010.IsNotEmpty Then
                    .Total10800502301000 += .cta_10800502301010
                End If
                If .cta_10800502301020.IsNotEmpty Then
                    .Total10800502301000 += .cta_10800502301020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502300000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502300000.cta_10800502302000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502300000.cta_10800502302000
                .Total10800502302000 = 0
                If .cta_10800502302010.IsNotEmpty Then
                    .Total10800502302000 += .cta_10800502302010
                End If
                If .cta_10800502302020.IsNotEmpty Then
                    .Total10800502302000 += .cta_10800502302020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502300000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502300000
                .Total10800502300000 = 0
                If .cta_10800502301000.IsNotEmpty AndAlso .cta_10800502301000.Total10800502301000.IsNotEmpty Then
                    .Total10800502300000 += .cta_10800502301000.Total10800502301000
                End If
                If .cta_10800502302000.IsNotEmpty AndAlso .cta_10800502302000.Total10800502302000.IsNotEmpty Then
                    .Total10800502300000 += .cta_10800502302000.Total10800502302000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502400000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502400000.cta_10800502401000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502400000.cta_10800502401000
                .Total10800502401000 = 0
                If .cta_10800502401010.IsNotEmpty Then
                    .Total10800502401000 += .cta_10800502401010
                End If
                If .cta_10800502401020.IsNotEmpty Then
                    .Total10800502401000 += .cta_10800502401020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502400000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502400000.cta_10800502402000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502400000.cta_10800502402000
                .Total10800502402000 = 0
                If .cta_10800502402010.IsNotEmpty Then
                    .Total10800502402000 += .cta_10800502402010
                End If
                If .cta_10800502402020.IsNotEmpty Then
                    .Total10800502402000 += .cta_10800502402020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502400000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502400000
                .Total10800502400000 = 0
                If .cta_10800502401000.IsNotEmpty AndAlso .cta_10800502401000.Total10800502401000.IsNotEmpty Then
                    .Total10800502400000 += .cta_10800502401000.Total10800502401000
                End If
                If .cta_10800502402000.IsNotEmpty AndAlso .cta_10800502402000.Total10800502402000.IsNotEmpty Then
                    .Total10800502400000 += .cta_10800502402000.Total10800502402000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502500000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502500000.cta_10800502501000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502500000.cta_10800502501000
                .Total10800502501000 = 0
                If .cta_10800502501010.IsNotEmpty Then
                    .Total10800502501000 += .cta_10800502501010
                End If
                If .cta_10800502501020.IsNotEmpty Then
                    .Total10800502501000 += .cta_10800502501020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502500000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502500000.cta_10800502502000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502500000.cta_10800502502000
                .Total10800502502000 = 0
                If .cta_10800502502010.IsNotEmpty Then
                    .Total10800502502000 += .cta_10800502502010
                End If
                If .cta_10800502502020.IsNotEmpty Then
                    .Total10800502502000 += .cta_10800502502020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502500000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502500000
                .Total10800502500000 = 0
                If .cta_10800502501000.IsNotEmpty AndAlso .cta_10800502501000.Total10800502501000.IsNotEmpty Then
                    .Total10800502500000 += .cta_10800502501000.Total10800502501000
                End If
                If .cta_10800502502000.IsNotEmpty AndAlso .cta_10800502502000.Total10800502502000.IsNotEmpty Then
                    .Total10800502500000 += .cta_10800502502000.Total10800502502000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502900000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502900000.cta_10800502901000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502900000.cta_10800502901000
                .Total10800502901000 = 0
                If .cta_10800502901010.IsNotEmpty Then
                    .Total10800502901000 += .cta_10800502901010
                End If
                If .cta_10800502901020.IsNotEmpty Then
                    .Total10800502901000 += .cta_10800502901020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502900000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502900000.cta_10800502902000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502900000.cta_10800502902000
                .Total10800502902000 = 0
                If .cta_10800502902010.IsNotEmpty Then
                    .Total10800502902000 += .cta_10800502902010
                End If
                If .cta_10800502902020.IsNotEmpty Then
                    .Total10800502902000 += .cta_10800502902020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502900000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502900000
                .Total10800502900000 = 0
                If .cta_10800502901000.IsNotEmpty AndAlso .cta_10800502901000.Total10800502901000.IsNotEmpty Then
                    .Total10800502900000 += .cta_10800502901000.Total10800502901000
                End If
                If .cta_10800502902000.IsNotEmpty AndAlso .cta_10800502902000.Total10800502902000.IsNotEmpty Then
                    .Total10800502900000 += .cta_10800502902000.Total10800502902000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000
                .Total10800500000000 = 0
                If .cta_10800502100000.IsNotEmpty AndAlso .cta_10800502100000.Total10800502100000.IsNotEmpty Then
                    .Total10800500000000 += .cta_10800502100000.Total10800502100000
                End If
                If .cta_10800502200000.IsNotEmpty AndAlso .cta_10800502200000.Total10800502200000.IsNotEmpty Then
                    .Total10800500000000 += .cta_10800502200000.Total10800502200000
                End If
                If .cta_10800502300000.IsNotEmpty AndAlso .cta_10800502300000.Total10800502300000.IsNotEmpty Then
                    .Total10800500000000 += .cta_10800502300000.Total10800502300000
                End If
                If .cta_10800502400000.IsNotEmpty AndAlso .cta_10800502400000.Total10800502400000.IsNotEmpty Then
                    .Total10800500000000 += .cta_10800502400000.Total10800502400000
                End If
                If .cta_10800502500000.IsNotEmpty AndAlso .cta_10800502500000.Total10800502500000.IsNotEmpty Then
                    .Total10800500000000 += .cta_10800502500000.Total10800502500000
                End If
                If .cta_10800502900000.IsNotEmpty AndAlso .cta_10800502900000.Total10800502900000.IsNotEmpty Then
                    .Total10800500000000 += .cta_10800502900000.Total10800502900000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800600000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800600000000.cta_10800600100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800600000000.cta_10800600100000
                .Total10800600100000 = 0
                If .cta_10800600101000.IsNotEmpty Then
                    .Total10800600100000 += .cta_10800600101000
                End If
                If .cta_10800600102000.IsNotEmpty Then
                    .Total10800600100000 += .cta_10800600102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800600000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800600000000.cta_10800600200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800600000000.cta_10800600200000
                .Total10800600200000 = 0
                If .cta_10800600201000.IsNotEmpty Then
                    .Total10800600200000 += .cta_10800600201000
                End If
                If .cta_10800600202000.IsNotEmpty Then
                    .Total10800600200000 += .cta_10800600202000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800600000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800600000000.cta_10800600300000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800600000000.cta_10800600300000
                .Total10800600300000 = 0
                If .cta_10800600301000.IsNotEmpty Then
                    .Total10800600300000 += .cta_10800600301000
                End If
                If .cta_10800600302000.IsNotEmpty Then
                    .Total10800600300000 += .cta_10800600302000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800600000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800600000000
                .Total10800600000000 = 0
                If .cta_10800600100000.IsNotEmpty AndAlso .cta_10800600100000.Total10800600100000.IsNotEmpty Then
                    .Total10800600000000 += .cta_10800600100000.Total10800600100000
                End If
                If .cta_10800600200000.IsNotEmpty AndAlso .cta_10800600200000.Total10800600200000.IsNotEmpty Then
                    .Total10800600000000 += .cta_10800600200000.Total10800600200000
                End If
                If .cta_10800600300000.IsNotEmpty AndAlso .cta_10800600300000.Total10800600300000.IsNotEmpty Then
                    .Total10800600000000 += .cta_10800600300000.Total10800600300000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800700000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800700000000.cta_10800700100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800700000000.cta_10800700100000
                .Total10800700100000 = 0
                If .cta_10800700101000.IsNotEmpty Then
                    .Total10800700100000 += .cta_10800700101000
                End If
                If .cta_10800700102000.IsNotEmpty Then
                    .Total10800700100000 += .cta_10800700102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800700000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800700000000.cta_10800700200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800700000000.cta_10800700200000
                .Total10800700200000 = 0
                If .cta_10800700201000.IsNotEmpty Then
                    .Total10800700200000 += .cta_10800700201000
                End If
                If .cta_10800700202000.IsNotEmpty Then
                    .Total10800700200000 += .cta_10800700202000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800700000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800700000000.cta_10800700300000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800700000000.cta_10800700300000
                .Total10800700300000 = 0
                If .cta_10800700301000.IsNotEmpty Then
                    .Total10800700300000 += .cta_10800700301000
                End If
                If .cta_10800700302000.IsNotEmpty Then
                    .Total10800700300000 += .cta_10800700302000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800700000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800700000000
                .Total10800700000000 = 0
                If .cta_10800700100000.IsNotEmpty AndAlso .cta_10800700100000.Total10800700100000.IsNotEmpty Then
                    .Total10800700000000 += .cta_10800700100000.Total10800700100000
                End If
                If .cta_10800700200000.IsNotEmpty AndAlso .cta_10800700200000.Total10800700200000.IsNotEmpty Then
                    .Total10800700000000 += .cta_10800700200000.Total10800700200000
                End If
                If .cta_10800700300000.IsNotEmpty AndAlso .cta_10800700300000.Total10800700300000.IsNotEmpty Then
                    .Total10800700000000 += .cta_10800700300000.Total10800700300000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800800000000.cta_10800800100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800800000000.cta_10800800100000
                .Total10800800100000 = 0
                If .cta_10800800101000.IsNotEmpty Then
                    .Total10800800100000 += .cta_10800800101000
                End If
                If .cta_10800800102000.IsNotEmpty Then
                    .Total10800800100000 += .cta_10800800102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800800000000.cta_10800800300000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800800000000.cta_10800800300000
                .Total10800800300000 = 0
                If .cta_10800800301000.IsNotEmpty Then
                    .Total10800800300000 += .cta_10800800301000
                End If
                If .cta_10800800302000.IsNotEmpty Then
                    .Total10800800300000 += .cta_10800800302000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800800000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800800000000
                .Total10800800000000 = 0
                If .cta_10800800100000.IsNotEmpty AndAlso .cta_10800800100000.Total10800800100000.IsNotEmpty Then
                    .Total10800800000000 += .cta_10800800100000.Total10800800100000
                End If
                If .cta_10800800300000.IsNotEmpty AndAlso .cta_10800800300000.Total10800800300000.IsNotEmpty Then
                    .Total10800800000000 += .cta_10800800300000.Total10800800300000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800900100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800900100000
                .Total10800900100000 = 0
                If .cta_10800900101000.IsNotEmpty Then
                    .Total10800900100000 += .cta_10800900101000
                End If
                If .cta_10800900102000.IsNotEmpty Then
                    .Total10800900100000 += .cta_10800900102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800900300000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800900300000
                .Total10800900300000 = 0
                If .cta_10800900301000.IsNotEmpty Then
                    .Total10800900300000 += .cta_10800900301000
                End If
                If .cta_10800900302000.IsNotEmpty Then
                    .Total10800900300000 += .cta_10800900302000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800900400000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800900400000
                .Total10800900400000 = 0
                If .cta_10800900401000.IsNotEmpty Then
                    .Total10800900400000 += .cta_10800900401000
                End If
                If .cta_10800900402000.IsNotEmpty Then
                    .Total10800900400000 += .cta_10800900402000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800900800000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800900800000
                .Total10800900800000 = 0
                If .cta_10800900801000.IsNotEmpty Then
                    .Total10800900800000 += .cta_10800900801000
                End If
                If .cta_10800900802000.IsNotEmpty Then
                    .Total10800900800000 += .cta_10800900802000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800900900000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800900900000
                .Total10800900900000 = 0
                If .cta_10800900901000.IsNotEmpty Then
                    .Total10800900900000 += .cta_10800900901000
                End If
                If .cta_10800900902000.IsNotEmpty Then
                    .Total10800900900000 += .cta_10800900902000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800902100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800902100000
                .Total10800902100000 = 0
                If .cta_10800902101000.IsNotEmpty Then
                    .Total10800902100000 += .cta_10800902101000
                End If
                If .cta_10800902102000.IsNotEmpty Then
                    .Total10800902100000 += .cta_10800902102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800902200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800902200000
                .Total10800902200000 = 0
                If .cta_10800902201000.IsNotEmpty Then
                    .Total10800902200000 += .cta_10800902201000
                End If
                If .cta_10800902202000.IsNotEmpty Then
                    .Total10800902200000 += .cta_10800902202000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800902300000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800902300000
                .Total10800902300000 = 0
                If .cta_10800902301000.IsNotEmpty Then
                    .Total10800902300000 += .cta_10800902301000
                End If
                If .cta_10800902302000.IsNotEmpty Then
                    .Total10800902300000 += .cta_10800902302000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800902400000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800902400000
                .Total10800902400000 = 0
                If .cta_10800902401000.IsNotEmpty Then
                    .Total10800902400000 += .cta_10800902401000
                End If
                If .cta_10800902402000.IsNotEmpty Then
                    .Total10800902400000 += .cta_10800902402000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800902500000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800902500000
                .Total10800902500000 = 0
                If .cta_10800902501000.IsNotEmpty Then
                    .Total10800902500000 += .cta_10800902501000
                End If
                If .cta_10800902502000.IsNotEmpty Then
                    .Total10800902500000 += .cta_10800902502000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800902900000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800902900000
                .Total10800902900000 = 0
                If .cta_10800902901000.IsNotEmpty Then
                    .Total10800902900000 += .cta_10800902901000
                End If
                If .cta_10800902902000.IsNotEmpty Then
                    .Total10800902900000 += .cta_10800902902000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800903300000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800903300000
                .Total10800903300000 = 0
                If .cta_10800903301000.IsNotEmpty Then
                    .Total10800903300000 += .cta_10800903301000
                End If
                If .cta_10800903302000.IsNotEmpty Then
                    .Total10800903300000 += .cta_10800903302000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000
                .Total10800900000000 = 0
                If .cta_10800900100000.IsNotEmpty AndAlso .cta_10800900100000.Total10800900100000.IsNotEmpty Then
                    .Total10800900000000 += .cta_10800900100000.Total10800900100000
                End If
                If .cta_10800900300000.IsNotEmpty AndAlso .cta_10800900300000.Total10800900300000.IsNotEmpty Then
                    .Total10800900000000 += .cta_10800900300000.Total10800900300000
                End If
                If .cta_10800900400000.IsNotEmpty AndAlso .cta_10800900400000.Total10800900400000.IsNotEmpty Then
                    .Total10800900000000 += .cta_10800900400000.Total10800900400000
                End If
                If .cta_10800900800000.IsNotEmpty AndAlso .cta_10800900800000.Total10800900800000.IsNotEmpty Then
                    .Total10800900000000 += .cta_10800900800000.Total10800900800000
                End If
                If .cta_10800900900000.IsNotEmpty AndAlso .cta_10800900900000.Total10800900900000.IsNotEmpty Then
                    .Total10800900000000 += .cta_10800900900000.Total10800900900000
                End If
                If .cta_10800902100000.IsNotEmpty AndAlso .cta_10800902100000.Total10800902100000.IsNotEmpty Then
                    .Total10800900000000 += .cta_10800902100000.Total10800902100000
                End If
                If .cta_10800902200000.IsNotEmpty AndAlso .cta_10800902200000.Total10800902200000.IsNotEmpty Then
                    .Total10800900000000 += .cta_10800902200000.Total10800902200000
                End If
                If .cta_10800902300000.IsNotEmpty AndAlso .cta_10800902300000.Total10800902300000.IsNotEmpty Then
                    .Total10800900000000 += .cta_10800902300000.Total10800902300000
                End If
                If .cta_10800902400000.IsNotEmpty AndAlso .cta_10800902400000.Total10800902400000.IsNotEmpty Then
                    .Total10800900000000 += .cta_10800902400000.Total10800902400000
                End If
                If .cta_10800902500000.IsNotEmpty AndAlso .cta_10800902500000.Total10800902500000.IsNotEmpty Then
                    .Total10800900000000 += .cta_10800902500000.Total10800902500000
                End If
                If .cta_10800902900000.IsNotEmpty AndAlso .cta_10800902900000.Total10800902900000.IsNotEmpty Then
                    .Total10800900000000 += .cta_10800902900000.Total10800902900000
                End If
                If .cta_10800903300000.IsNotEmpty AndAlso .cta_10800903300000.Total10800903300000.IsNotEmpty Then
                    .Total10800900000000 += .cta_10800903300000.Total10800903300000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10800000000000
                .Total10800000000000 = 0
                If .cta_10800200000000.IsNotEmpty AndAlso .cta_10800200000000.Total10800200000000.IsNotEmpty Then
                    .Total10800000000000 += .cta_10800200000000.Total10800200000000
                End If
                If .cta_10800300000000.IsNotEmpty AndAlso .cta_10800300000000.Total10800300000000.IsNotEmpty Then
                    .Total10800000000000 += .cta_10800300000000.Total10800300000000
                End If
                If .cta_10800400000000.IsNotEmpty AndAlso .cta_10800400000000.Total10800400000000.IsNotEmpty Then
                    .Total10800000000000 += .cta_10800400000000.Total10800400000000
                End If
                If .cta_10800500000000.IsNotEmpty AndAlso .cta_10800500000000.Total10800500000000.IsNotEmpty Then
                    .Total10800000000000 += .cta_10800500000000.Total10800500000000
                End If
                If .cta_10800600000000.IsNotEmpty AndAlso .cta_10800600000000.Total10800600000000.IsNotEmpty Then
                    .Total10800000000000 += .cta_10800600000000.Total10800600000000
                End If
                If .cta_10800700000000.IsNotEmpty AndAlso .cta_10800700000000.Total10800700000000.IsNotEmpty Then
                    .Total10800000000000 += .cta_10800700000000.Total10800700000000
                End If
                If .cta_10800800000000.IsNotEmpty AndAlso .cta_10800800000000.Total10800800000000.IsNotEmpty Then
                    .Total10800000000000 += .cta_10800800000000.Total10800800000000
                End If
                If .cta_10800900000000.IsNotEmpty AndAlso .cta_10800900000000.Total10800900000000.IsNotEmpty Then
                    .Total10800000000000 += .cta_10800900000000.Total10800900000000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000.cta_10900100200000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000.cta_10900100200000.cta_10900100201000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000.cta_10900100200000.cta_10900100201000
                .Total10900100201000 = 0
                If .cta_10900100201010.IsNotEmpty Then
                    .Total10900100201000 += .cta_10900100201010
                End If
                If .cta_10900100201990.IsNotEmpty Then
                    .Total10900100201000 += .cta_10900100201990
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000.cta_10900100200000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000.cta_10900100200000.cta_10900100202000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000.cta_10900100200000.cta_10900100202000
                .Total10900100202000 = 0
                If .cta_10900100202010.IsNotEmpty Then
                    .Total10900100202000 += .cta_10900100202010
                End If
                If .cta_10900100202990.IsNotEmpty Then
                    .Total10900100202000 += .cta_10900100202990
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000.cta_10900100200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000.cta_10900100200000
                .Total10900100200000 = 0
                If .cta_10900100201000.IsNotEmpty AndAlso .cta_10900100201000.Total10900100201000.IsNotEmpty Then
                    .Total10900100200000 += .cta_10900100201000.Total10900100201000
                End If
                If .cta_10900100202000.IsNotEmpty AndAlso .cta_10900100202000.Total10900100202000.IsNotEmpty Then
                    .Total10900100200000 += .cta_10900100202000.Total10900100202000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000.cta_10900100300000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000.cta_10900100300000
                .Total10900100300000 = 0
                If .cta_10900100301000.IsNotEmpty Then
                    .Total10900100300000 += .cta_10900100301000
                End If
                If .cta_10900100302000.IsNotEmpty Then
                    .Total10900100300000 += .cta_10900100302000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000.cta_10900100400000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000.cta_10900100400000
                .Total10900100400000 = 0
                If .cta_10900100401000.IsNotEmpty Then
                    .Total10900100400000 += .cta_10900100401000
                End If
                If .cta_10900100402000.IsNotEmpty Then
                    .Total10900100400000 += .cta_10900100402000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000.cta_10900109900000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000.cta_10900109900000
                .Total10900109900000 = 0
                If .cta_10900109901000.IsNotEmpty Then
                    .Total10900109900000 += .cta_10900109901000
                End If
                If .cta_10900109902000.IsNotEmpty Then
                    .Total10900109900000 += .cta_10900109902000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000
                .Total10900100000000 = 0
                If .cta_10900100200000.IsNotEmpty AndAlso .cta_10900100200000.Total10900100200000.IsNotEmpty Then
                    .Total10900100000000 += .cta_10900100200000.Total10900100200000
                End If
                If .cta_10900100300000.IsNotEmpty AndAlso .cta_10900100300000.Total10900100300000.IsNotEmpty Then
                    .Total10900100000000 += .cta_10900100300000.Total10900100300000
                End If
                If .cta_10900100400000.IsNotEmpty AndAlso .cta_10900100400000.Total10900100400000.IsNotEmpty Then
                    .Total10900100000000 += .cta_10900100400000.Total10900100400000
                End If
                If .cta_10900109900000.IsNotEmpty AndAlso .cta_10900109900000.Total10900109900000.IsNotEmpty Then
                    .Total10900100000000 += .cta_10900109900000.Total10900109900000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900200200000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900200200000.cta_10900200201000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900200200000.cta_10900200201000
                .Total10900200201000 = 0
                If .cta_10900200201010.IsNotEmpty Then
                    .Total10900200201000 += .cta_10900200201010
                End If
                If .cta_10900200201020.IsNotEmpty Then
                    .Total10900200201000 += .cta_10900200201020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900200200000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900200200000.cta_10900200202000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900200200000.cta_10900200202000
                .Total10900200202000 = 0
                If .cta_10900200202010.IsNotEmpty Then
                    .Total10900200202000 += .cta_10900200202010
                End If
                If .cta_10900200202020.IsNotEmpty Then
                    .Total10900200202000 += .cta_10900200202020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900200200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900200200000
                .Total10900200200000 = 0
                If .cta_10900200201000.IsNotEmpty AndAlso .cta_10900200201000.Total10900200201000.IsNotEmpty Then
                    .Total10900200200000 += .cta_10900200201000.Total10900200201000
                End If
                If .cta_10900200202000.IsNotEmpty AndAlso .cta_10900200202000.Total10900200202000.IsNotEmpty Then
                    .Total10900200200000 += .cta_10900200202000.Total10900200202000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900200300000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900200300000
                .Total10900200300000 = 0
                If .cta_10900200301000.IsNotEmpty Then
                    .Total10900200300000 += .cta_10900200301000
                End If
                If .cta_10900200302000.IsNotEmpty Then
                    .Total10900200300000 += .cta_10900200302000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900200400000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900200400000
                .Total10900200400000 = 0
                If .cta_10900200401000.IsNotEmpty Then
                    .Total10900200400000 += .cta_10900200401000
                End If
                If .cta_10900200402000.IsNotEmpty Then
                    .Total10900200400000 += .cta_10900200402000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900209900000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900209900000.cta_10900209901000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900209900000.cta_10900209901000
                .Total10900209901000 = 0
                If .cta_10900209901010.IsNotEmpty Then
                    .Total10900209901000 += .cta_10900209901010
                End If
                If .cta_10900209901020.IsNotEmpty Then
                    .Total10900209901000 += .cta_10900209901020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900209900000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900209900000.cta_10900209902000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900209900000.cta_10900209902000
                .Total10900209902000 = 0
                If .cta_10900209902010.IsNotEmpty Then
                    .Total10900209902000 += .cta_10900209902010
                End If
                If .cta_10900209902020.IsNotEmpty Then
                    .Total10900209902000 += .cta_10900209902020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900209900000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900209900000
                .Total10900209900000 = 0
                If .cta_10900209901000.IsNotEmpty AndAlso .cta_10900209901000.Total10900209901000.IsNotEmpty Then
                    .Total10900209900000 += .cta_10900209901000.Total10900209901000
                End If
                If .cta_10900209902000.IsNotEmpty AndAlso .cta_10900209902000.Total10900209902000.IsNotEmpty Then
                    .Total10900209900000 += .cta_10900209902000.Total10900209902000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000
                .Total10900200000000 = 0
                If .cta_10900200200000.IsNotEmpty AndAlso .cta_10900200200000.Total10900200200000.IsNotEmpty Then
                    .Total10900200000000 += .cta_10900200200000.Total10900200200000
                End If
                If .cta_10900200300000.IsNotEmpty AndAlso .cta_10900200300000.Total10900200300000.IsNotEmpty Then
                    .Total10900200000000 += .cta_10900200300000.Total10900200300000
                End If
                If .cta_10900200400000.IsNotEmpty AndAlso .cta_10900200400000.Total10900200400000.IsNotEmpty Then
                    .Total10900200000000 += .cta_10900200400000.Total10900200400000
                End If
                If .cta_10900209900000.IsNotEmpty AndAlso .cta_10900209900000.Total10900209900000.IsNotEmpty Then
                    .Total10900200000000 += .cta_10900209900000.Total10900209900000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300200000
                .Total10900300200000 = 0
                If .cta_10900300201000.IsNotEmpty Then
                    .Total10900300200000 += .cta_10900300201000
                End If
                If .cta_10900300202000.IsNotEmpty Then
                    .Total10900300200000 += .cta_10900300202000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300400000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300400000.cta_10900300401000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300400000.cta_10900300401000
                .Total10900300401000 = 0
                If .cta_10900300401010.IsNotEmpty Then
                    .Total10900300401000 += .cta_10900300401010
                End If
                If .cta_10900300401020.IsNotEmpty Then
                    .Total10900300401000 += .cta_10900300401020
                End If
                If .cta_10900300401030.IsNotEmpty Then
                    .Total10900300401000 += .cta_10900300401030
                End If
                If .cta_10900300401040.IsNotEmpty Then
                    .Total10900300401000 += .cta_10900300401040
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300400000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300400000.cta_10900300402000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300400000.cta_10900300402000
                .Total10900300402000 = 0
                If .cta_10900300402010.IsNotEmpty Then
                    .Total10900300402000 += .cta_10900300402010
                End If
                If .cta_10900300402020.IsNotEmpty Then
                    .Total10900300402000 += .cta_10900300402020
                End If
                If .cta_10900300402030.IsNotEmpty Then
                    .Total10900300402000 += .cta_10900300402030
                End If
                If .cta_10900300402040.IsNotEmpty Then
                    .Total10900300402000 += .cta_10900300402040
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300400000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300400000
                .Total10900300400000 = 0
                If .cta_10900300401000.IsNotEmpty AndAlso .cta_10900300401000.Total10900300401000.IsNotEmpty Then
                    .Total10900300400000 += .cta_10900300401000.Total10900300401000
                End If
                If .cta_10900300402000.IsNotEmpty AndAlso .cta_10900300402000.Total10900300402000.IsNotEmpty Then
                    .Total10900300400000 += .cta_10900300402000.Total10900300402000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300500000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300500000
                .Total10900300500000 = 0
                If .cta_10900300501000.IsNotEmpty Then
                    .Total10900300500000 += .cta_10900300501000
                End If
                If .cta_10900300502000.IsNotEmpty Then
                    .Total10900300500000 += .cta_10900300502000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300600000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300600000.cta_10900300601000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300600000.cta_10900300601000
                .Total10900300601000 = 0
                If .cta_10900300601010.IsNotEmpty Then
                    .Total10900300601000 += .cta_10900300601010
                End If
                If .cta_10900300601020.IsNotEmpty Then
                    .Total10900300601000 += .cta_10900300601020
                End If
                If .cta_10900300601030.IsNotEmpty Then
                    .Total10900300601000 += .cta_10900300601030
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300600000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300600000.cta_10900300602000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300600000.cta_10900300602000
                .Total10900300602000 = 0
                If .cta_10900300602010.IsNotEmpty Then
                    .Total10900300602000 += .cta_10900300602010
                End If
                If .cta_10900300602020.IsNotEmpty Then
                    .Total10900300602000 += .cta_10900300602020
                End If
                If .cta_10900300602030.IsNotEmpty Then
                    .Total10900300602000 += .cta_10900300602030
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300600000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300600000
                .Total10900300600000 = 0
                If .cta_10900300601000.IsNotEmpty AndAlso .cta_10900300601000.Total10900300601000.IsNotEmpty Then
                    .Total10900300600000 += .cta_10900300601000.Total10900300601000
                End If
                If .cta_10900300602000.IsNotEmpty AndAlso .cta_10900300602000.Total10900300602000.IsNotEmpty Then
                    .Total10900300600000 += .cta_10900300602000.Total10900300602000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300700000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300700000.cta_10900300701000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300700000.cta_10900300701000
                .Total10900300701000 = 0
                If .cta_10900300701010.IsNotEmpty Then
                    .Total10900300701000 += .cta_10900300701010
                End If
                If .cta_10900300701020.IsNotEmpty Then
                    .Total10900300701000 += .cta_10900300701020
                End If
                If .cta_10900300701030.IsNotEmpty Then
                    .Total10900300701000 += .cta_10900300701030
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300700000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300700000.cta_10900300702000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300700000.cta_10900300702000
                .Total10900300702000 = 0
                If .cta_10900300702010.IsNotEmpty Then
                    .Total10900300702000 += .cta_10900300702010
                End If
                If .cta_10900300702020.IsNotEmpty Then
                    .Total10900300702000 += .cta_10900300702020
                End If
                If .cta_10900300702030.IsNotEmpty Then
                    .Total10900300702000 += .cta_10900300702030
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300700000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300700000
                .Total10900300700000 = 0
                If .cta_10900300701000.IsNotEmpty AndAlso .cta_10900300701000.Total10900300701000.IsNotEmpty Then
                    .Total10900300700000 += .cta_10900300701000.Total10900300701000
                End If
                If .cta_10900300702000.IsNotEmpty AndAlso .cta_10900300702000.Total10900300702000.IsNotEmpty Then
                    .Total10900300700000 += .cta_10900300702000.Total10900300702000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300800000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300800000
                .Total10900300800000 = 0
                If .cta_10900300801000.IsNotEmpty Then
                    .Total10900300800000 += .cta_10900300801000
                End If
                If .cta_10900300802000.IsNotEmpty Then
                    .Total10900300800000 += .cta_10900300802000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300900000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300900000
                .Total10900300900000 = 0
                If .cta_10900300901000.IsNotEmpty Then
                    .Total10900300900000 += .cta_10900300901000
                End If
                If .cta_10900300902000.IsNotEmpty Then
                    .Total10900300900000 += .cta_10900300902000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900309900000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900309900000
                .Total10900309900000 = 0
                If .cta_10900309901000.IsNotEmpty Then
                    .Total10900309900000 += .cta_10900309901000
                End If
                If .cta_10900309902000.IsNotEmpty Then
                    .Total10900309900000 += .cta_10900309902000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000
                .Total10900300000000 = 0
                If .cta_10900300200000.IsNotEmpty AndAlso .cta_10900300200000.Total10900300200000.IsNotEmpty Then
                    .Total10900300000000 += .cta_10900300200000.Total10900300200000
                End If
                If .cta_10900300400000.IsNotEmpty AndAlso .cta_10900300400000.Total10900300400000.IsNotEmpty Then
                    .Total10900300000000 += .cta_10900300400000.Total10900300400000
                End If
                If .cta_10900300500000.IsNotEmpty AndAlso .cta_10900300500000.Total10900300500000.IsNotEmpty Then
                    .Total10900300000000 += .cta_10900300500000.Total10900300500000
                End If
                If .cta_10900300600000.IsNotEmpty AndAlso .cta_10900300600000.Total10900300600000.IsNotEmpty Then
                    .Total10900300000000 += .cta_10900300600000.Total10900300600000
                End If
                If .cta_10900300700000.IsNotEmpty AndAlso .cta_10900300700000.Total10900300700000.IsNotEmpty Then
                    .Total10900300000000 += .cta_10900300700000.Total10900300700000
                End If
                If .cta_10900300800000.IsNotEmpty AndAlso .cta_10900300800000.Total10900300800000.IsNotEmpty Then
                    .Total10900300000000 += .cta_10900300800000.Total10900300800000
                End If
                If .cta_10900300900000.IsNotEmpty AndAlso .cta_10900300900000.Total10900300900000.IsNotEmpty Then
                    .Total10900300000000 += .cta_10900300900000.Total10900300900000
                End If
                If .cta_10900309900000.IsNotEmpty AndAlso .cta_10900309900000.Total10900309900000.IsNotEmpty Then
                    .Total10900300000000 += .cta_10900309900000.Total10900309900000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900400000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900400000000.cta_10900400100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900400000000.cta_10900400100000
                .Total10900400100000 = 0
                If .cta_10900400101000.IsNotEmpty Then
                    .Total10900400100000 += .cta_10900400101000
                End If
                If .cta_10900400102000.IsNotEmpty Then
                    .Total10900400100000 += .cta_10900400102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900400000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900400000000.cta_10900400200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900400000000.cta_10900400200000
                .Total10900400200000 = 0
                If .cta_10900400201000.IsNotEmpty Then
                    .Total10900400200000 += .cta_10900400201000
                End If
                If .cta_10900400202000.IsNotEmpty Then
                    .Total10900400200000 += .cta_10900400202000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900400000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900400000000.cta_10900409900000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900400000000.cta_10900409900000
                .Total10900409900000 = 0
                If .cta_10900409901000.IsNotEmpty Then
                    .Total10900409900000 += .cta_10900409901000
                End If
                If .cta_10900409902000.IsNotEmpty Then
                    .Total10900409900000 += .cta_10900409902000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900400000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900400000000
                .Total10900400000000 = 0
                If .cta_10900400100000.IsNotEmpty AndAlso .cta_10900400100000.Total10900400100000.IsNotEmpty Then
                    .Total10900400000000 += .cta_10900400100000.Total10900400100000
                End If
                If .cta_10900400200000.IsNotEmpty AndAlso .cta_10900400200000.Total10900400200000.IsNotEmpty Then
                    .Total10900400000000 += .cta_10900400200000.Total10900400200000
                End If
                If .cta_10900409900000.IsNotEmpty AndAlso .cta_10900409900000.Total10900409900000.IsNotEmpty Then
                    .Total10900400000000 += .cta_10900409900000.Total10900409900000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900500000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900500000000.cta_10900500100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900500000000.cta_10900500100000
                .Total10900500100000 = 0
                If .cta_10900500101000.IsNotEmpty Then
                    .Total10900500100000 += .cta_10900500101000
                End If
                If .cta_10900500102000.IsNotEmpty Then
                    .Total10900500100000 += .cta_10900500102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900500000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900500000000.cta_10900500200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900500000000.cta_10900500200000
                .Total10900500200000 = 0
                If .cta_10900500201000.IsNotEmpty Then
                    .Total10900500200000 += .cta_10900500201000
                End If
                If .cta_10900500202000.IsNotEmpty Then
                    .Total10900500200000 += .cta_10900500202000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900500000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900500000000.cta_10900500400000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900500000000.cta_10900500400000
                .Total10900500400000 = 0
                If .cta_10900500401000.IsNotEmpty Then
                    .Total10900500400000 += .cta_10900500401000
                End If
                If .cta_10900500402000.IsNotEmpty Then
                    .Total10900500400000 += .cta_10900500402000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900500000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900500000000
                .Total10900500000000 = 0
                If .cta_10900500100000.IsNotEmpty AndAlso .cta_10900500100000.Total10900500100000.IsNotEmpty Then
                    .Total10900500000000 += .cta_10900500100000.Total10900500100000
                End If
                If .cta_10900500200000.IsNotEmpty AndAlso .cta_10900500200000.Total10900500200000.IsNotEmpty Then
                    .Total10900500000000 += .cta_10900500200000.Total10900500200000
                End If
                If .cta_10900500400000.IsNotEmpty AndAlso .cta_10900500400000.Total10900500400000.IsNotEmpty Then
                    .Total10900500000000 += .cta_10900500400000.Total10900500400000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900600200000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900600200000.cta_10900600201000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900600200000.cta_10900600201000
                .Total10900600201000 = 0
                If .cta_10900600201010.IsNotEmpty Then
                    .Total10900600201000 += .cta_10900600201010
                End If
                If .cta_10900600201030.IsNotEmpty Then
                    .Total10900600201000 += .cta_10900600201030
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900600200000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900600200000.cta_10900600202000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900600200000.cta_10900600202000
                .Total10900600202000 = 0
                If .cta_10900600202010.IsNotEmpty Then
                    .Total10900600202000 += .cta_10900600202010
                End If
                If .cta_10900600202030.IsNotEmpty Then
                    .Total10900600202000 += .cta_10900600202030
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900600200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900600200000
                .Total10900600200000 = 0
                If .cta_10900600201000.IsNotEmpty AndAlso .cta_10900600201000.Total10900600201000.IsNotEmpty Then
                    .Total10900600200000 += .cta_10900600201000.Total10900600201000
                End If
                If .cta_10900600202000.IsNotEmpty AndAlso .cta_10900600202000.Total10900600202000.IsNotEmpty Then
                    .Total10900600200000 += .cta_10900600202000.Total10900600202000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900600400000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900600400000.cta_10900600401000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900600400000.cta_10900600401000
                .Total10900600401000 = 0
                If .cta_10900600401010.IsNotEmpty Then
                    .Total10900600401000 += .cta_10900600401010
                End If
                If .cta_10900600401020.IsNotEmpty Then
                    .Total10900600401000 += .cta_10900600401020
                End If
                If .cta_10900600401030.IsNotEmpty Then
                    .Total10900600401000 += .cta_10900600401030
                End If
                If .cta_10900600401040.IsNotEmpty Then
                    .Total10900600401000 += .cta_10900600401040
                End If
                If .cta_10900600401050.IsNotEmpty Then
                    .Total10900600401000 += .cta_10900600401050
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900600400000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900600400000.cta_10900600402000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900600400000.cta_10900600402000
                .Total10900600402000 = 0
                If .cta_10900600402010.IsNotEmpty Then
                    .Total10900600402000 += .cta_10900600402010
                End If
                If .cta_10900600402020.IsNotEmpty Then
                    .Total10900600402000 += .cta_10900600402020
                End If
                If .cta_10900600402030.IsNotEmpty Then
                    .Total10900600402000 += .cta_10900600402030
                End If
                If .cta_10900600402040.IsNotEmpty Then
                    .Total10900600402000 += .cta_10900600402040
                End If
                If .cta_10900600402050.IsNotEmpty Then
                    .Total10900600402000 += .cta_10900600402050
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900600400000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900600400000
                .Total10900600400000 = 0
                If .cta_10900600401000.IsNotEmpty AndAlso .cta_10900600401000.Total10900600401000.IsNotEmpty Then
                    .Total10900600400000 += .cta_10900600401000.Total10900600401000
                End If
                If .cta_10900600402000.IsNotEmpty AndAlso .cta_10900600402000.Total10900600402000.IsNotEmpty Then
                    .Total10900600400000 += .cta_10900600402000.Total10900600402000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900609900000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900609900000.cta_10900609901000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900609900000.cta_10900609901000
                .Total10900609901000 = 0
                If .cta_10900609901010.IsNotEmpty Then
                    .Total10900609901000 += .cta_10900609901010
                End If
                If .cta_10900609901020.IsNotEmpty Then
                    .Total10900609901000 += .cta_10900609901020
                End If
                If .cta_10900609901030.IsNotEmpty Then
                    .Total10900609901000 += .cta_10900609901030
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900609900000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900609900000.cta_10900609902000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900609900000.cta_10900609902000
                .Total10900609902000 = 0
                If .cta_10900609902010.IsNotEmpty Then
                    .Total10900609902000 += .cta_10900609902010
                End If
                If .cta_10900609902020.IsNotEmpty Then
                    .Total10900609902000 += .cta_10900609902020
                End If
                If .cta_10900609902030.IsNotEmpty Then
                    .Total10900609902000 += .cta_10900609902030
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900609900000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900609900000
                .Total10900609900000 = 0
                If .cta_10900609901000.IsNotEmpty AndAlso .cta_10900609901000.Total10900609901000.IsNotEmpty Then
                    .Total10900609900000 += .cta_10900609901000.Total10900609901000
                End If
                If .cta_10900609902000.IsNotEmpty AndAlso .cta_10900609902000.Total10900609902000.IsNotEmpty Then
                    .Total10900609900000 += .cta_10900609902000.Total10900609902000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000
                .Total10900600000000 = 0
                If .cta_10900600200000.IsNotEmpty AndAlso .cta_10900600200000.Total10900600200000.IsNotEmpty Then
                    .Total10900600000000 += .cta_10900600200000.Total10900600200000
                End If
                If .cta_10900600400000.IsNotEmpty AndAlso .cta_10900600400000.Total10900600400000.IsNotEmpty Then
                    .Total10900600000000 += .cta_10900600400000.Total10900600400000
                End If
                If .cta_10900609900000.IsNotEmpty AndAlso .cta_10900609900000.Total10900609900000.IsNotEmpty Then
                    .Total10900600000000 += .cta_10900609900000.Total10900609900000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000.cta_10900700100000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000.cta_10900700100000.cta_10900700101000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000.cta_10900700100000.cta_10900700101000
                .Total10900700101000 = 0
                If .cta_10900700101010.IsNotEmpty Then
                    .Total10900700101000 += .cta_10900700101010
                End If
                If .cta_10900700101020.IsNotEmpty Then
                    .Total10900700101000 += .cta_10900700101020
                End If
                If .cta_10900700101030.IsNotEmpty Then
                    .Total10900700101000 += .cta_10900700101030
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000.cta_10900700100000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000.cta_10900700100000.cta_10900700102000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000.cta_10900700100000.cta_10900700102000
                .Total10900700102000 = 0
                If .cta_10900700102010.IsNotEmpty Then
                    .Total10900700102000 += .cta_10900700102010
                End If
                If .cta_10900700102020.IsNotEmpty Then
                    .Total10900700102000 += .cta_10900700102020
                End If
                If .cta_10900700102030.IsNotEmpty Then
                    .Total10900700102000 += .cta_10900700102030
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000.cta_10900700100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000.cta_10900700100000
                .Total10900700100000 = 0
                If .cta_10900700101000.IsNotEmpty AndAlso .cta_10900700101000.Total10900700101000.IsNotEmpty Then
                    .Total10900700100000 += .cta_10900700101000.Total10900700101000
                End If
                If .cta_10900700102000.IsNotEmpty AndAlso .cta_10900700102000.Total10900700102000.IsNotEmpty Then
                    .Total10900700100000 += .cta_10900700102000.Total10900700102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000.cta_10900700200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000.cta_10900700200000
                .Total10900700200000 = 0
                If .cta_10900700201000.IsNotEmpty Then
                    .Total10900700200000 += .cta_10900700201000
                End If
                If .cta_10900700202000.IsNotEmpty Then
                    .Total10900700200000 += .cta_10900700202000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000.cta_10900700300000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000.cta_10900700300000
                .Total10900700300000 = 0
                If .cta_10900700301000.IsNotEmpty Then
                    .Total10900700300000 += .cta_10900700301000
                End If
                If .cta_10900700302000.IsNotEmpty Then
                    .Total10900700300000 += .cta_10900700302000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000
                .Total10900700000000 = 0
                If .cta_10900700100000.IsNotEmpty AndAlso .cta_10900700100000.Total10900700100000.IsNotEmpty Then
                    .Total10900700000000 += .cta_10900700100000.Total10900700100000
                End If
                If .cta_10900700200000.IsNotEmpty AndAlso .cta_10900700200000.Total10900700200000.IsNotEmpty Then
                    .Total10900700000000 += .cta_10900700200000.Total10900700200000
                End If
                If .cta_10900700300000.IsNotEmpty AndAlso .cta_10900700300000.Total10900700300000.IsNotEmpty Then
                    .Total10900700000000 += .cta_10900700300000.Total10900700300000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900800000000.cta_10900800100000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900800000000.cta_10900800100000.cta_10900800101000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900800000000.cta_10900800100000.cta_10900800101000
                .Total10900800101000 = 0
                If .cta_10900800101010.IsNotEmpty Then
                    .Total10900800101000 += .cta_10900800101010
                End If
                If .cta_10900800101020.IsNotEmpty Then
                    .Total10900800101000 += .cta_10900800101020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900800000000.cta_10900800100000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900800000000.cta_10900800100000.cta_10900800102000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900800000000.cta_10900800100000.cta_10900800102000
                .Total10900800102000 = 0
                If .cta_10900800102010.IsNotEmpty Then
                    .Total10900800102000 += .cta_10900800102010
                End If
                If .cta_10900800102020.IsNotEmpty Then
                    .Total10900800102000 += .cta_10900800102020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900800000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900800000000.cta_10900800100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900800000000.cta_10900800100000
                .Total10900800100000 = 0
                If .cta_10900800101000.IsNotEmpty AndAlso .cta_10900800101000.Total10900800101000.IsNotEmpty Then
                    .Total10900800100000 += .cta_10900800101000.Total10900800101000
                End If
                If .cta_10900800102000.IsNotEmpty AndAlso .cta_10900800102000.Total10900800102000.IsNotEmpty Then
                    .Total10900800100000 += .cta_10900800102000.Total10900800102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900800000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900800000000
                .Total10900800000000 = 0
                If .cta_10900800100000.IsNotEmpty AndAlso .cta_10900800100000.Total10900800100000.IsNotEmpty Then
                    .Total10900800000000 += .cta_10900800100000.Total10900800100000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900900000000.cta_10900900100000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900900000000.cta_10900900100000.cta_10900900101000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900900000000.cta_10900900100000.cta_10900900101000
                .Total10900900101000 = 0
                If .cta_10900900101010.IsNotEmpty Then
                    .Total10900900101000 += .cta_10900900101010
                End If
                If .cta_10900900101020.IsNotEmpty Then
                    .Total10900900101000 += .cta_10900900101020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900900000000.cta_10900900100000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900900000000.cta_10900900100000.cta_10900900102000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900900000000.cta_10900900100000.cta_10900900102000
                .Total10900900102000 = 0
                If .cta_10900900102010.IsNotEmpty Then
                    .Total10900900102000 += .cta_10900900102010
                End If
                If .cta_10900900102020.IsNotEmpty Then
                    .Total10900900102000 += .cta_10900900102020
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900900000000.cta_10900900100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900900000000.cta_10900900100000
                .Total10900900100000 = 0
                If .cta_10900900101000.IsNotEmpty AndAlso .cta_10900900101000.Total10900900101000.IsNotEmpty Then
                    .Total10900900100000 += .cta_10900900101000.Total10900900101000
                End If
                If .cta_10900900102000.IsNotEmpty AndAlso .cta_10900900102000.Total10900900102000.IsNotEmpty Then
                    .Total10900900100000 += .cta_10900900102000.Total10900900102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900900000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10900900000000
                .Total10900900000000 = 0
                If .cta_10900900100000.IsNotEmpty AndAlso .cta_10900900100000.Total10900900100000.IsNotEmpty Then
                    .Total10900900000000 += .cta_10900900100000.Total10900900100000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10901000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10901000000000.cta_10901000100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10901000000000.cta_10901000100000
                .Total10901000100000 = 0
                If .cta_10901000101000.IsNotEmpty Then
                    .Total10901000100000 += .cta_10901000101000
                End If
                If .cta_10901000102000.IsNotEmpty Then
                    .Total10901000100000 += .cta_10901000102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10901000000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.cta_10901000000000
                .Total10901000000000 = 0
                If .cta_10901000100000.IsNotEmpty AndAlso .cta_10901000100000.Total10901000100000.IsNotEmpty Then
                    .Total10901000000000 += .cta_10901000100000.Total10901000100000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_10900000000000
                .Total10900000000000 = 0
                If .cta_10900100000000.IsNotEmpty AndAlso .cta_10900100000000.Total10900100000000.IsNotEmpty Then
                    .Total10900000000000 += .cta_10900100000000.Total10900100000000
                End If
                If .cta_10900200000000.IsNotEmpty AndAlso .cta_10900200000000.Total10900200000000.IsNotEmpty Then
                    .Total10900000000000 += .cta_10900200000000.Total10900200000000
                End If
                If .cta_10900300000000.IsNotEmpty AndAlso .cta_10900300000000.Total10900300000000.IsNotEmpty Then
                    .Total10900000000000 += .cta_10900300000000.Total10900300000000
                End If
                If .cta_10900400000000.IsNotEmpty AndAlso .cta_10900400000000.Total10900400000000.IsNotEmpty Then
                    .Total10900000000000 += .cta_10900400000000.Total10900400000000
                End If
                If .cta_10900500000000.IsNotEmpty AndAlso .cta_10900500000000.Total10900500000000.IsNotEmpty Then
                    .Total10900000000000 += .cta_10900500000000.Total10900500000000
                End If
                If .cta_10900600000000.IsNotEmpty AndAlso .cta_10900600000000.Total10900600000000.IsNotEmpty Then
                    .Total10900000000000 += .cta_10900600000000.Total10900600000000
                End If
                If .cta_10900700000000.IsNotEmpty AndAlso .cta_10900700000000.Total10900700000000.IsNotEmpty Then
                    .Total10900000000000 += .cta_10900700000000.Total10900700000000
                End If
                If .cta_10900800000000.IsNotEmpty AndAlso .cta_10900800000000.Total10900800000000.IsNotEmpty Then
                    .Total10900000000000 += .cta_10900800000000.Total10900800000000
                End If
                If .cta_10900900000000.IsNotEmpty AndAlso .cta_10900900000000.Total10900900000000.IsNotEmpty Then
                    .Total10900000000000 += .cta_10900900000000.Total10900900000000
                End If
                If .cta_10901000000000.IsNotEmpty AndAlso .cta_10901000000000.Total10901000000000.IsNotEmpty Then
                    .Total10900000000000 += .cta_10901000000000.Total10901000000000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000100000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000100000000.cta_11000100100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000100000000.cta_11000100100000
                .Total11000100100000 = 0
                If .cta_11000100101000.IsNotEmpty Then
                    .Total11000100100000 += .cta_11000100101000
                End If
                If .cta_11000100102000.IsNotEmpty Then
                    .Total11000100100000 += .cta_11000100102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000100000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000100000000.cta_11000100200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000100000000.cta_11000100200000
                .Total11000100200000 = 0
                If .cta_11000100201000.IsNotEmpty Then
                    .Total11000100200000 += .cta_11000100201000
                End If
                If .cta_11000100202000.IsNotEmpty Then
                    .Total11000100200000 += .cta_11000100202000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000100000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000100000000.cta_11000100900000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000100000000.cta_11000100900000
                .Total11000100900000 = 0
                If .cta_11000100901000.IsNotEmpty Then
                    .Total11000100900000 += .cta_11000100901000
                End If
                If .cta_11000100902000.IsNotEmpty Then
                    .Total11000100900000 += .cta_11000100902000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000100000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000100000000
                .Total11000100000000 = 0
                If .cta_11000100100000.IsNotEmpty AndAlso .cta_11000100100000.Total11000100100000.IsNotEmpty Then
                    .Total11000100000000 += .cta_11000100100000.Total11000100100000
                End If
                If .cta_11000100200000.IsNotEmpty AndAlso .cta_11000100200000.Total11000100200000.IsNotEmpty Then
                    .Total11000100000000 += .cta_11000100200000.Total11000100200000
                End If
                If .cta_11000100900000.IsNotEmpty AndAlso .cta_11000100900000.Total11000100900000.IsNotEmpty Then
                    .Total11000100000000 += .cta_11000100900000.Total11000100900000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200100000
                .Total11000200100000 = 0
                If .cta_11000200101000.IsNotEmpty Then
                    .Total11000200100000 += .cta_11000200101000
                End If
                If .cta_11000200102000.IsNotEmpty Then
                    .Total11000200100000 += .cta_11000200102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200200000
                .Total11000200200000 = 0
                If .cta_11000200201000.IsNotEmpty Then
                    .Total11000200200000 += .cta_11000200201000
                End If
                If .cta_11000200202000.IsNotEmpty Then
                    .Total11000200200000 += .cta_11000200202000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200400000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200400000.cta_11000200401000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200400000.cta_11000200401000
                .Total11000200401000 = 0
                If .cta_11000200401020.IsNotEmpty Then
                    .Total11000200401000 += .cta_11000200401020
                End If
                If .cta_11000200401030.IsNotEmpty Then
                    .Total11000200401000 += .cta_11000200401030
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200400000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200400000.cta_11000200402000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200400000.cta_11000200402000
                .Total11000200402000 = 0
                If .cta_11000200402020.IsNotEmpty Then
                    .Total11000200402000 += .cta_11000200402020
                End If
                If .cta_11000200402030.IsNotEmpty Then
                    .Total11000200402000 += .cta_11000200402030
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200400000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200400000
                .Total11000200400000 = 0
                If .cta_11000200401000.IsNotEmpty AndAlso .cta_11000200401000.Total11000200401000.IsNotEmpty Then
                    .Total11000200400000 += .cta_11000200401000.Total11000200401000
                End If
                If .cta_11000200402000.IsNotEmpty AndAlso .cta_11000200402000.Total11000200402000.IsNotEmpty Then
                    .Total11000200400000 += .cta_11000200402000.Total11000200402000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200900000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200900000.cta_11000200901000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200900000.cta_11000200901000
                .Total11000200901000 = 0
                If .cta_11000200901020.IsNotEmpty Then
                    .Total11000200901000 += .cta_11000200901020
                End If
                If .cta_11000200901030.IsNotEmpty Then
                    .Total11000200901000 += .cta_11000200901030
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200900000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200900000.cta_11000200902000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200900000.cta_11000200902000
                .Total11000200902000 = 0
                If .cta_11000200902020.IsNotEmpty Then
                    .Total11000200902000 += .cta_11000200902020
                End If
                If .cta_11000200902030.IsNotEmpty Then
                    .Total11000200902000 += .cta_11000200902030
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200900000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200900000
                .Total11000200900000 = 0
                If .cta_11000200901000.IsNotEmpty AndAlso .cta_11000200901000.Total11000200901000.IsNotEmpty Then
                    .Total11000200900000 += .cta_11000200901000.Total11000200901000
                End If
                If .cta_11000200902000.IsNotEmpty AndAlso .cta_11000200902000.Total11000200902000.IsNotEmpty Then
                    .Total11000200900000 += .cta_11000200902000.Total11000200902000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000201900000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000201900000.cta_11000201901000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000201900000.cta_11000201901000
                .Total11000201901000 = 0
                If .cta_11000201901020.IsNotEmpty Then
                    .Total11000201901000 += .cta_11000201901020
                End If
                If .cta_11000201901030.IsNotEmpty Then
                    .Total11000201901000 += .cta_11000201901030
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000201900000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000201900000.cta_11000201902000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000201900000.cta_11000201902000
                .Total11000201902000 = 0
                If .cta_11000201902020.IsNotEmpty Then
                    .Total11000201902000 += .cta_11000201902020
                End If
                If .cta_11000201902030.IsNotEmpty Then
                    .Total11000201902000 += .cta_11000201902030
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000201900000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000201900000
                .Total11000201900000 = 0
                If .cta_11000201901000.IsNotEmpty AndAlso .cta_11000201901000.Total11000201901000.IsNotEmpty Then
                    .Total11000201900000 += .cta_11000201901000.Total11000201901000
                End If
                If .cta_11000201902000.IsNotEmpty AndAlso .cta_11000201902000.Total11000201902000.IsNotEmpty Then
                    .Total11000201900000 += .cta_11000201902000.Total11000201902000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000
                .Total11000200000000 = 0
                If .cta_11000200100000.IsNotEmpty AndAlso .cta_11000200100000.Total11000200100000.IsNotEmpty Then
                    .Total11000200000000 += .cta_11000200100000.Total11000200100000
                End If
                If .cta_11000200200000.IsNotEmpty AndAlso .cta_11000200200000.Total11000200200000.IsNotEmpty Then
                    .Total11000200000000 += .cta_11000200200000.Total11000200200000
                End If
                If .cta_11000200400000.IsNotEmpty AndAlso .cta_11000200400000.Total11000200400000.IsNotEmpty Then
                    .Total11000200000000 += .cta_11000200400000.Total11000200400000
                End If
                If .cta_11000200900000.IsNotEmpty AndAlso .cta_11000200900000.Total11000200900000.IsNotEmpty Then
                    .Total11000200000000 += .cta_11000200900000.Total11000200900000
                End If
                If .cta_11000201900000.IsNotEmpty AndAlso .cta_11000201900000.Total11000201900000.IsNotEmpty Then
                    .Total11000200000000 += .cta_11000201900000.Total11000201900000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11000000000000
                .Total11000000000000 = 0
                If .cta_11000100000000.IsNotEmpty AndAlso .cta_11000100000000.Total11000100000000.IsNotEmpty Then
                    .Total11000000000000 += .cta_11000100000000.Total11000100000000
                End If
                If .cta_11000200000000.IsNotEmpty AndAlso .cta_11000200000000.Total11000200000000.IsNotEmpty Then
                    .Total11000000000000 += .cta_11000200000000.Total11000200000000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100100000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100100000000.cta_11100100100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100100000000.cta_11100100100000
                .Total11100100100000 = 0
                If .cta_11100100101000.IsNotEmpty Then
                    .Total11100100100000 += .cta_11100100101000
                End If
                If .cta_11100100102000.IsNotEmpty Then
                    .Total11100100100000 += .cta_11100100102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100100000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100100000000.cta_11100100200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100100000000.cta_11100100200000
                .Total11100100200000 = 0
                If .cta_11100100201000.IsNotEmpty Then
                    .Total11100100200000 += .cta_11100100201000
                End If
                If .cta_11100100202000.IsNotEmpty Then
                    .Total11100100200000 += .cta_11100100202000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100100000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100100000000
                .Total11100100000000 = 0
                If .cta_11100100100000.IsNotEmpty AndAlso .cta_11100100100000.Total11100100100000.IsNotEmpty Then
                    .Total11100100000000 += .cta_11100100100000.Total11100100100000
                End If
                If .cta_11100100200000.IsNotEmpty AndAlso .cta_11100100200000.Total11100100200000.IsNotEmpty Then
                    .Total11100100000000 += .cta_11100100200000.Total11100100200000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100200000000.cta_11100200100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100200000000.cta_11100200100000
                .Total11100200100000 = 0
                If .cta_11100200101000.IsNotEmpty Then
                    .Total11100200100000 += .cta_11100200101000
                End If
                If .cta_11100200102000.IsNotEmpty Then
                    .Total11100200100000 += .cta_11100200102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100200000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100200000000.cta_11100200200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100200000000.cta_11100200200000
                .Total11100200200000 = 0
                If .cta_11100200201000.IsNotEmpty Then
                    .Total11100200200000 += .cta_11100200201000
                End If
                If .cta_11100200202000.IsNotEmpty Then
                    .Total11100200200000 += .cta_11100200202000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100200000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100200000000
                .Total11100200000000 = 0
                If .cta_11100200100000.IsNotEmpty AndAlso .cta_11100200100000.Total11100200100000.IsNotEmpty Then
                    .Total11100200000000 += .cta_11100200100000.Total11100200100000
                End If
                If .cta_11100200200000.IsNotEmpty AndAlso .cta_11100200200000.Total11100200200000.IsNotEmpty Then
                    .Total11100200000000 += .cta_11100200200000.Total11100200200000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100300000000.cta_11100300100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100300000000.cta_11100300100000
                .Total11100300100000 = 0
                If .cta_11100300101000.IsNotEmpty Then
                    .Total11100300100000 += .cta_11100300101000
                End If
                If .cta_11100300102000.IsNotEmpty Then
                    .Total11100300100000 += .cta_11100300102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100300000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100300000000.cta_11100300200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100300000000.cta_11100300200000
                .Total11100300200000 = 0
                If .cta_11100300201000.IsNotEmpty Then
                    .Total11100300200000 += .cta_11100300201000
                End If
                If .cta_11100300202000.IsNotEmpty Then
                    .Total11100300200000 += .cta_11100300202000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100300000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100300000000
                .Total11100300000000 = 0
                If .cta_11100300100000.IsNotEmpty AndAlso .cta_11100300100000.Total11100300100000.IsNotEmpty Then
                    .Total11100300000000 += .cta_11100300100000.Total11100300100000
                End If
                If .cta_11100300200000.IsNotEmpty AndAlso .cta_11100300200000.Total11100300200000.IsNotEmpty Then
                    .Total11100300000000 += .cta_11100300200000.Total11100300200000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100400000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100400000000.cta_11100400100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100400000000.cta_11100400100000
                .Total11100400100000 = 0
                If .cta_11100400101000.IsNotEmpty Then
                    .Total11100400100000 += .cta_11100400101000
                End If
                If .cta_11100400102000.IsNotEmpty Then
                    .Total11100400100000 += .cta_11100400102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100400000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100400000000.cta_11100400200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100400000000.cta_11100400200000
                .Total11100400200000 = 0
                If .cta_11100400201000.IsNotEmpty Then
                    .Total11100400200000 += .cta_11100400201000
                End If
                If .cta_11100400202000.IsNotEmpty Then
                    .Total11100400200000 += .cta_11100400202000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100400000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100400000000.cta_11100400300000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100400000000.cta_11100400300000
                .Total11100400300000 = 0
                If .cta_11100400301000.IsNotEmpty Then
                    .Total11100400300000 += .cta_11100400301000
                End If
                If .cta_11100400302000.IsNotEmpty Then
                    .Total11100400300000 += .cta_11100400302000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100400000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100400000000
                .Total11100400000000 = 0
                If .cta_11100400100000.IsNotEmpty AndAlso .cta_11100400100000.Total11100400100000.IsNotEmpty Then
                    .Total11100400000000 += .cta_11100400100000.Total11100400100000
                End If
                If .cta_11100400200000.IsNotEmpty AndAlso .cta_11100400200000.Total11100400200000.IsNotEmpty Then
                    .Total11100400000000 += .cta_11100400200000.Total11100400200000
                End If
                If .cta_11100400300000.IsNotEmpty AndAlso .cta_11100400300000.Total11100400300000.IsNotEmpty Then
                    .Total11100400000000 += .cta_11100400300000.Total11100400300000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100900000000.cta_11100900100000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100900000000.cta_11100900100000
                .Total11100900100000 = 0
                If .cta_11100900101000.IsNotEmpty Then
                    .Total11100900100000 += .cta_11100900101000
                End If
                If .cta_11100900102000.IsNotEmpty Then
                    .Total11100900100000 += .cta_11100900102000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100900000000.cta_11100900200000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100900000000.cta_11100900200000
                .Total11100900200000 = 0
                If .cta_11100900201000.IsNotEmpty Then
                    .Total11100900200000 += .cta_11100900201000
                End If
                If .cta_11100900202000.IsNotEmpty Then
                    .Total11100900200000 += .cta_11100900202000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100900000000.cta_11100900300000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100900000000.cta_11100900300000
                .Total11100900300000 = 0
                If .cta_11100900301000.IsNotEmpty Then
                    .Total11100900300000 += .cta_11100900301000
                End If
                If .cta_11100900302000.IsNotEmpty Then
                    .Total11100900300000 += .cta_11100900302000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100900000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100900000000.cta_11100900400000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100900000000.cta_11100900400000
                .Total11100900400000 = 0
                If .cta_11100900401000.IsNotEmpty Then
                    .Total11100900400000 += .cta_11100900401000
                End If
                If .cta_11100900402000.IsNotEmpty Then
                    .Total11100900400000 += .cta_11100900402000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100900000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.cta_11100900000000
                .Total11100900000000 = 0
                If .cta_11100900100000.IsNotEmpty AndAlso .cta_11100900100000.Total11100900100000.IsNotEmpty Then
                    .Total11100900000000 += .cta_11100900100000.Total11100900100000
                End If
                If .cta_11100900200000.IsNotEmpty AndAlso .cta_11100900200000.Total11100900200000.IsNotEmpty Then
                    .Total11100900000000 += .cta_11100900200000.Total11100900200000
                End If
                If .cta_11100900300000.IsNotEmpty AndAlso .cta_11100900300000.Total11100900300000.IsNotEmpty Then
                    .Total11100900000000 += .cta_11100900300000.Total11100900300000
                End If
                If .cta_11100900400000.IsNotEmpty AndAlso .cta_11100900400000.Total11100900400000.IsNotEmpty Then
                    .Total11100900000000 += .cta_11100900400000.Total11100900400000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000.cta_11100000000000
                .Total11100000000000 = 0
                If .cta_11100100000000.IsNotEmpty AndAlso .cta_11100100000000.Total11100100000000.IsNotEmpty Then
                    .Total11100000000000 += .cta_11100100000000.Total11100100000000
                End If
                If .cta_11100200000000.IsNotEmpty AndAlso .cta_11100200000000.Total11100200000000.IsNotEmpty Then
                    .Total11100000000000 += .cta_11100200000000.Total11100200000000
                End If
                If .cta_11100300000000.IsNotEmpty AndAlso .cta_11100300000000.Total11100300000000.IsNotEmpty Then
                    .Total11100000000000 += .cta_11100300000000.Total11100300000000
                End If
                If .cta_11100400000000.IsNotEmpty AndAlso .cta_11100400000000.Total11100400000000.IsNotEmpty Then
                    .Total11100000000000 += .cta_11100400000000.Total11100400000000
                End If
                If .cta_11100900000000.IsNotEmpty AndAlso .cta_11100900000000.Total11100900000000.IsNotEmpty Then
                    .Total11100000000000 += .cta_11100900000000.Total11100900000000
                End If
            End With
        End If
        If _SaldosContables.IsNotEmpty AndAlso _SaldosContables.Datos.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.IsNotEmpty AndAlso _SaldosContables.Datos.Modelo.cta_10000000000000.IsNotEmpty Then
            With _SaldosContables.Datos.Modelo.cta_10000000000000
                .Total10000000000000 = 0
                If .cta_10100000000000.IsNotEmpty AndAlso .cta_10100000000000.Total10100000000000.IsNotEmpty Then
                    .Total10000000000000 += .cta_10100000000000.Total10100000000000
                End If
                If .cta_10200000000000.IsNotEmpty AndAlso .cta_10200000000000.Total10200000000000.IsNotEmpty Then
                    .Total10000000000000 += .cta_10200000000000.Total10200000000000
                End If
                If .cta_10300000000000.IsNotEmpty AndAlso .cta_10300000000000.Total10300000000000.IsNotEmpty Then
                    .Total10000000000000 += .cta_10300000000000.Total10300000000000
                End If
                If .cta_10400000000000.IsNotEmpty AndAlso .cta_10400000000000.Total10400000000000.IsNotEmpty Then
                    .Total10000000000000 += .cta_10400000000000.Total10400000000000
                End If
                If .cta_10500000000000.IsNotEmpty AndAlso .cta_10500000000000.Total10500000000000.IsNotEmpty Then
                    .Total10000000000000 += .cta_10500000000000.Total10500000000000
                End If
                If .cta_10600000000000.IsNotEmpty AndAlso .cta_10600000000000.Total10600000000000.IsNotEmpty Then
                    .Total10000000000000 += .cta_10600000000000.Total10600000000000
                End If
                If .cta_10700000000000.IsNotEmpty AndAlso .cta_10700000000000.Total10700000000000.IsNotEmpty Then
                    .Total10000000000000 += .cta_10700000000000.Total10700000000000
                End If
                If .cta_10800000000000.IsNotEmpty AndAlso .cta_10800000000000.Total10800000000000.IsNotEmpty Then
                    .Total10000000000000 += .cta_10800000000000.Total10800000000000
                End If
                If .cta_10900000000000.IsNotEmpty AndAlso .cta_10900000000000.Total10900000000000.IsNotEmpty Then
                    .Total10000000000000 += .cta_10900000000000.Total10900000000000
                End If
                If .cta_11000000000000.IsNotEmpty AndAlso .cta_11000000000000.Total11000000000000.IsNotEmpty Then
                    .Total10000000000000 += .cta_11000000000000.Total11000000000000
                End If
                If .cta_11100000000000.IsNotEmpty AndAlso .cta_11100000000000.Total11100000000000.IsNotEmpty Then
                    .Total10000000000000 += .cta_11100000000000.Total11100000000000
                End If
            End With
        End If

    End Sub

End Class
