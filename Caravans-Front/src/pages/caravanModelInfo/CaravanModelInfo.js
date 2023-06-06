import React, { Component } from 'react';
import withRouter from '../../actions/withRouter';
import { getCaravanModelsById } from "../../actions/caravanModelAction";
import { addReservation } from '../../actions/reservationsActions';
import { getToken } from '../../actions/userActions';
import './CaravanModelInfo.css';


 
class CaravanModelInfo extends Component{
    state = {
        caravans: [],
        begin:null,
        end:null,
        error:null
    }
    componentDidMount() {
        getCaravanModelsById(this.props.params.id)
          .then(res => {
            if(res){
                const caravans = res.data;
                this.setState({ caravans : caravans });
            }
        })
    }

    handleReservation = () => {
        const userId = getToken().UserId;
        const { begin, end} = this.state;
        const modelId = this.props.params.id;
        const reservation = { userId, modelId, begin, end };
        if(!reservation.begin || !reservation.end)
            this.setState({ error : "Wybierz datę" });
        if(userId!=null&&modelId!=null&&begin!=null&&end!=null)
        addReservation(reservation).then((res) => {
            if (res && res.status === 200) {
                window.location.href = "/reservations";
            }else
                this.setState({ error : res.data });
        });
    };

    render() {
        var caravanModel = this.state.caravans;
        if(caravanModel.hotWater)
            caravanModel.hotWater = "posiada";
        else
            caravanModel.hotWater = "nie posiada";

        if(caravanModel.shower)
            caravanModel.shower = "posiada";
        else
            caravanModel.shower = "nie posiada";

        if(caravanModel.fridge)
            caravanModel.fridge = "posiada";
        else
            caravanModel.fridge = "nie posiada";

        return ( 
        <>
            <h1>{caravanModel.producer} {caravanModel.model}</h1>
            <div className="caravanInfo">        

                <table className="specyfication">
                    <tbody>
                        <tr> 
                            <td>Masa </td>
                            <td>{caravanModel.weight}kg</td> 
                            
                        </tr>
                        <tr> 
                            <td>Długość całkowita  </td>
                            <td>{caravanModel.length}mm</td>
                        </tr>
                        <tr> 
                            <td>Długość wnętrza  </td>
                            <td>{caravanModel.lengthInside}mm</td>
                        </tr>
                        <tr> 
                            <td>Szerokość całkowita  </td>
                            <td>{caravanModel.width}mm</td> 
                        </tr>
                        <tr> 
                            <td>Szerokość wnętrza  </td>  
                            <td>{caravanModel.widthInside}mm</td> 
                        </tr>
                        <tr> 
                            <td>Ilość miejsc  </td>  
                            <td>{caravanModel.people}</td>
                        </tr>
                        <tr>  
                            <td>Woda  </td>  
                            <td>{caravanModel.water}l</td> 
                        </tr>
                        <tr> 
                            <td>Ciepła woda  </td>  
                            <td>{caravanModel.hotWater}</td> 
                        </tr>
                        <tr> 
                            <td>Prysznic  </td>  
                            <td>{caravanModel.shower}</td>
                        </tr>
                        <tr>     
                            <td>Lodówka  </td>  
                            <td>{caravanModel.fridge}</td> 
                        </tr>
                    </tbody>
                </table>

                <img src={`/Images/caravans/${caravanModel.picture}`} alt="przyczepa"/>
            </div>
            <div className="addReservation">
                <p>{caravanModel.price}PLN/dzień</p>
                <label>Początek<input type="date" onChange={(event) => this.setState({begin: event.target.value})}/></label>
                <label>Koniec <input type="date" onChange={(event) => this.setState({end: event.target.value})}/></label>
                <button onClick={() => this.handleReservation()}>Dodaj rezerwację</button>
            </div> 
            {this.state.error? <p className="error">{this.state.error}</p> : ""}
        </>
        )
    }
}
export default withRouter(CaravanModelInfo);