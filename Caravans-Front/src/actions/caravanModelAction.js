import axios from "axios";
import { hostName } from "./host";

export const getCaravanModels = async () => {
	try {
		const res = await axios.get(`${hostName}/api/Caravanmodel`);
		return await res;
	} catch (error) {
		console.log(error);
	}
};

export const getCaravanModelsById = async (modelId) => {
	try {
		const res = await axios.get(`${hostName}/api/Caravanmodel/${modelId}`);
		return await res;
	} catch (error) {
		console.log(error);
	}
};