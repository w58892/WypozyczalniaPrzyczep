import React, { Component } from "react";
import { getToken } from "../../actions/userActions";
import { getByUser, removeReservation, getReservationPDF, confirmReservation } from "../../actions/reservationsActions";
import './Reservations.css';
import moment from 'moment';

class Reservations extends Component {
  state = {
    reservations: []
  }

  componentDidMount() {
    const token = getToken();
    if (!token)
      window.location.href = "/";
    else
    {
    getByUser(token.UserId)
      .then(res => {
        const reservations = res.data;
        this.setState({ reservations: reservations });
      })
    }
  }

  render() {     
    if(!this.state.reservations[0])
      return(<p className="noneRes">Brak rezerwacji</p>)
    else
      return(
        <table className="reservations">
          <tbody>
          {
            this.state.reservations
              .map((reservations ,i)=>
                  
              <tr key={i}>
                <td >{reservations.caravanmodel.producer}</td>
                <td >{reservations.caravanmodel.model}</td>
                <td >OD {moment(reservations.reservation.reservationBegin).format('DD.MM.YYYY')}</td>
                <td >DO {moment(reservations.reservation.reservationEnd).format('DD.MM.YYYY')}</td>
                {reservations.reservation.reservationConfirmed?
                  <td className="buttonPDF" colSpan={2}>
                    <button
                      onClick={() => getReservationPDF(reservations.reservation.reservationId)}>
                      Pobierz fakturę
                    </button>
                  </td>
                :
                  <td><button
                    onClick={() => confirmReservation(reservations.reservation.reservationId)}>
                    Zatwierdź
                  </button></td>
                }

                {reservations.reservation.reservationConfirmed? "":
                  <td><button
                    onClick={() => removeReservation(reservations.reservation.reservationId)}>
                    Usuń
                  </button></td>
                }
              </tr>
            )
          }
        </tbody>					
      </table>
    )
  }
}
export default Reservations;