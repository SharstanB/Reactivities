import CounterStore from "./CounterStore";
import { createContext } from "react";
import { UiStore } from "./UIStore";
interface Store {
  counterStore: CounterStore;
  uiStore: UiStore;
}

export const store: Store = {
  counterStore: new CounterStore(),
  uiStore: new UiStore(),
}
export const StoreContext = createContext<Store>(store);
