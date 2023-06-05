import axios from "axios";
import { hostName } from "./host";

export const getCaravans = async () => {
	try {
		const res = await axios.get(`${hostName}/api/Caravan`);
		return await res;
	} catch (error) {
		console.log(error);
	}
};

export const getCaravansById = async (caravanId) => {
	try {
		const res = await axios.get(`${hostName}/api/Caravan/${caravanId}`);
		return await res;
	} catch (error) {
		console.log(error);
	}
};