import axios from "axios";
import { hostName } from "./host";

export const getCaravanModels = async () => {
	const res = await axios.get(`${hostName}/api/Caravanmodel`)
		.catch(err => {
            console.log(err)
        });
		return res;

};

export const getCaravanModelsById = async (modelId) => {
	try {
		const res = await axios.get(`${hostName}/api/Caravanmodel/${modelId}`);
		return res;
	} catch (error) {
		console.log(error);
	}
};