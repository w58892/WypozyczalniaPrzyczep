import axios from "axios";
import { hostName } from "./host";

export const getByUser = async (userId) => {
    const res = await axios.get(`${hostName}/api/Reservation/GetByUser/${userId}`, {		
        headers: {
            Authorization: `Bearer ${localStorage.getItem("token")}`
        }}).catch(err => {
            console.log(err)
        });
    return res;
};

export const addReservation = async (reservation) => {
    try{
        const res = await axios.post(`${hostName}/api/Reservation/Add`,reservation, {		
            headers: {
                Authorization: `Bearer ${localStorage.getItem("token")}`
            }})
        return res;
    }catch(error){
        return error.response;
    }
};

export const confirmReservation = async (reservationId) => {
    try{
        const res = await axios.get(`${hostName}/api/Reservation/ConfirmReservation/${reservationId}`, {		
            headers: {
                Authorization: `Bearer ${localStorage.getItem("token")}`
            }})
        if(res)
            window.location.reload();
    }catch(error){
        return error.response;
    }
};

export const removeReservation = async (reservationID) => {
    try{
        const res = await axios.get(`${hostName}/api/Reservation/Delete/${reservationID}`, {		
            headers: {
                Authorization: `Bearer ${localStorage.getItem("token")}`
        }});
        if(res)
            window.location.reload();
    }catch(error){
        console.log(error);
    }
};

export const getReservationPDF = async (reservationID) => {
    try{
        axios(`${hostName}/api/Reservation/GetPdf/${reservationID}`, {
            method: 'GET',
            headers: {
                Authorization: `Bearer ${localStorage.getItem("token")}`,
            },
            responseType: 'blob' 
        })
        .then(response => {
            const file = new Blob(
            [response.data], 
            {type: 'application/pdf'});
            const fileURL = URL.createObjectURL(file);
            window.open(fileURL);})
        .catch(error => {
            console.log(error);
        });
    }catch(error){
        console.log(error);
    }
}