using FluentBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBuilder.Builder
{
    public class CuentaFluentBuilder
    {
        private readonly Cuenta _cuenta;

        public static CuentaFluentBuilder Crear(TipoCuenta tipo)
        {
            return new CuentaFluentBuilder(tipo);
        }

        private CuentaFluentBuilder(TipoCuenta tipo)
        {
            _cuenta = new Cuenta { tipo = tipo };
        }

        public CuentaFluentBuilder NumeroCuenta(int numero)
        {
            _cuenta.numero = numero;
            return this;
        }

        public CuentaFluentBuilder Propietario(string propietario)
        {
            _cuenta.propietario = propietario;
            return this;
        }

        public CuentaFluentBuilder Tasa(double tasa)
        {
            _cuenta.tasa = tasa;
            return this;
        }

        public CuentaFluentBuilder SaldoInicial(double saldo)
        {
            _cuenta.saldo = saldo;
            return this;
        }

        public Cuenta GenerarCuenta()
        {
            return _cuenta;
        }
    }
}
