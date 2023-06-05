import React, { Component } from "react";
import { Link } from "react-router-dom";
import { getCaravanModels } from "../../actions/caravanModelAction";
import './CaravanModel.css';

export class CaravanModel extends Component {
  state = {
    caravans: []
  }

  componentDidMount() {
    getCaravanModels()
      .then(res => {
        const caravans = res.data;
        this.setState({ caravans });
    })
  }

  render() {
    return (
      <div className="grid">        
        <img src='../../images/slider.jpg'></img>
        <h1>Przyczepy kempingowe na wynajem</h1>

        {
          this.state.caravans
            .map(caravanModel =>
              <ul className="caravan" key={caravanModel.modelId}>
                <img src={`../../images/caravans/${caravanModel.picture}`}></img>
                <li className="model">{caravanModel.model}</li>
                <li className="price">{caravanModel.price} PLN/dzień</li>
                <li>Długość: {caravanModel.length} mm</li>
                <li>Liczba miejsc: {caravanModel.people}</li>
                <li>masa: {caravanModel.weight}kg</li>

                <Link to={{     
                  pathname: `/caravanModelInfo/${caravanModel.modelId}`,
                }}> 
                  <button>Więcej</button>
                </Link>
              </ul>
            )
      }
      </div>
    );
  }
}
export default CaravanModel;