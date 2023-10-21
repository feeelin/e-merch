import axios from "axios";

export default class PostService{

    static async getAll(){
        let response = await axios.get('https://emerch.nakodeelee.ru/api/product')
        return response.data
    }

    static async getOne(id){
        let response = await axios.get(`https://emerch.nakodeelee.ru/api/product/${id}`)
        return response.data
    }
}