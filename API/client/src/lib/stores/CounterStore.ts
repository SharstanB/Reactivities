import { makeAutoObservable } from "mobx";

export default class CounterStore {
  count = 0;
  title = "Counter";
  events: string[] = [];
  constructor() {
    makeAutoObservable(this);
  }
  increment(amount: number = 1) {
    this.count+= amount;
    this.events.push(`Incremented by ${amount} - count is now ${this.title}`);
  }
  decrement(amount: number = 1) {
    this.count-= amount;
    this.events.push(`Decremented by ${amount} - count is now ${this.title}`);
  }
  get countString() {
    return this.events.length;
  }
}
