<template>
  <div class="keepsComponent card mb-2" :data-target="'#keep-modal-'+keepProp.id" data-toggle="modal">
    <img :src="keepProp.img" class="img-fluid">
    <h4>
      {{ keepProp.name }}
    </h4>
  </div>
  <!-- Modal -->
  <div class="modal"
       :id="'keep-modal-'+keepProp.id"
       tabindex="-1"
       role="dialog"
       aria-labelledby="Close"
       aria-hidden="true"
  >
    <div class="modal-fullscreen" role="document">
      <div class="modal-content">
        <button type="button" class="close text-right pr-2" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
        <div class="row">
          <div class="col-6">
            <img class="imageFit" :src="keepProp.img">
          </div>
          <div class="col-6 text-center">
            <div>
              <h2>{{ keepProp.name }}</h2>
            </div>
            <div>
              {{ keepProp.description }}
            </div>
            <div class="modal-footer col-12 d-flex justify-content-around align-content flex-end">
              <div class="dropdown">
                <button class="btn btn-outline-primary dropdown-toggle" type="button" id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-expanded="false">
                  Dropdown button
                </button>
                <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                  <li><a class="dropdown-item" href="#">Action</a></li>
                  <li><a class="dropdown-item" href="#">Another action</a></li>
                  <li><a class="dropdown-item" href="#">Something else here</a></li>
                </ul>
              </div>
              <i class="fa fa-trash-o fa-2x text-danger" aria-hidden="true"></i>
              <router-link :to="{name: 'ProfilePage', params: {id: keepProp.creator.id }}">
                <i class="fa fa-user" aria-hidden="true">{{ keepProp.creator.name }}</i>
              </router-link>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { reactive } from 'vue'
// import { AppState } from '../AppState'
export default {
  name: 'KeepsComponent',
  props: {
    keepProp: { type: Object, required: true }
  },
  setup(props) {
    const state = reactive({
      // vaults: computed(() => AppState.vaults.filter(l => l.id !== props.keepProp.vault))
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

.modal-footer{
  position: absolute;
  bottom: 0;
}

.img {
  background-image: ;
}

</style>
