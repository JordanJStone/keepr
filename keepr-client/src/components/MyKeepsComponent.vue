<template>
  <div class="myKeepsComponent card mb-2 img-fluid">
    <img :src="keepProp.img">
    <h4>
      {{ keepProp.name }}
    </h4>
  </div>
</template>

<script>
import { reactive } from 'vue'
// import { AppState } from '../AppState'
export default {
  name: 'MyKeepsComponent',
  props: {
    keepProp: { type: Object, required: true }
  },
  setup(props) {
    const state = reactive({
    })
    return { state }
  }
}
</script>

<style scoped>
/* .imageFit{
  height: 100%;
  width: 100%;
  object-fit: contain;
  } */

</style>
