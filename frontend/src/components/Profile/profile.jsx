import React, {useEffect, useState} from 'react';
import axios from "axios";
import classes from './profile.module.css'

const Profile = ({user}) => {

    let purchasesList = []
    let [purchases, setPurchases] = useState([])
    let [idToSend, sendIdToSend] = useState('')
    let [number, setNumber] = useState(0)
    let [text, setText] = useState('Поделиться монетами')

    useEffect(
        () => {
            axios.get(`https://emerch.nakodeelee.ru/api/customer/${user.id}/history`)
                .then(response => response.data)
                .then(data => setPurchases(data.purchases))
                .catch(error => console.log(error))
        }, []
    )

    purchases?.map(purchase =>
        purchasesList.push(
            <div className={classes.purchase}>
                <p key={purchase.id}>{purchase.title} - {purchase.count}</p>
            </div>
        )
    )

    const sendMoney = () => {
        axios.put(`https://emerch.nakodeelee.ru/api/Customer/from/${user.id}/to/${idToSend}/${number}`)
            .then(response => response.data)
            .then(data => setText('Отправлено!'))
            .catch(error => setText('Не удалось отправить('))
    }


    return (
        <div className={classes.container}>
            <div>
                <h3>История покупок</h3>
                {purchasesList.length ? purchasesList : <p>Пока пусто</p>}
            </div>
            <div className={classes.giveMoney}>
                <div>
                    <h4>Ваш ID:</h4>
                    <p> {user.id}</p>
                </div>
                <h3>Поделиться монетами</h3>
                <input type='text' placeholder={'Введите ID'} value={idToSend} onChange={(event) => sendIdToSend(event.target.value)}/>
                <input type='number' placeholder={'Введите количество'} aria-valuemax={user.eCoins} value={number}
                       onChange={(event) => setNumber(event.target.value)}/>
                <button onClick={sendMoney}>Отправить</button>
            </div>
        </div>
    );
}

export default Profile;