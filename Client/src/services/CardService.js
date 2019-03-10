import axios from 'axios'

export default class CardService {
    static create(data, onSuccess, onError) {
        console.log('card create data: ', data)
        axios.post(`/api/card/post`, data)
            .then(response => onSuccess(response))
            .catch(err => onError(err))
    }
}